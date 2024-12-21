using Domain.Entities.Business;
using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.Helpers.MailHelper;
using E_Association.Service.IAssociationServices.IEmailSender;
using E_Association.Service.IAssociationServices.Userservice;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.Userservice
{
    public class AssociationService : IAssociationService
    {
        private readonly AppDbContext _app;
        private IEmailSender _emailSender;
        public AssociationService(AppDbContext app, IEmailSender emailSender)
        {
            this._app = app;
            this._emailSender = emailSender;
        }

        public async ValueTask<string> ApplyToAssociation(string applicantName,string associationName, int getCashInMonth)
        {
            if (string.IsNullOrEmpty(associationName)||string.IsNullOrEmpty(applicantName) || getCashInMonth < 0)
                throw new Exception("Invalid Data");

            var association = await _app.Associations.SingleOrDefaultAsync(x=>x.Name == associationName);
            if (association is null)
                throw new Exception("Association Not Found");

            var applicant = await _app.users.SingleOrDefaultAsync(x => x.UserName == applicantName);
            if (applicant is null)
                throw new Exception("applicant Not Found or you need To Create Account");

            association.Applicants++;
            var message = $"Your application to join the association {association.Name} has been approved. We will send you more details.";
            var message2 = $"We regret to inform you that the association you want to join is full. You can choose another association.";
                
            return association.Applicants > association.Capacity ?
                  await MailHelper.SendMailToOne(_emailSender, applicant.Email!, association.Name, message) :
                  await MailHelper.SendMailToOne(_emailSender, applicant.Email!, association.Name, message);
        }

        public async ValueTask<string> CreateAssociationAsync(Association subscription)
        {
            if (subscription is null) 
                throw new ArgumentNullException("Invalid Data");

            await _app.Associations.AddAsync(subscription);
            var creation = _app.SaveChanges();
            return creation > 0 ? "Created Successfuly" : "Invalid Creation";
        }

        public async ValueTask<string> DeleteSubscriptionAsync(string Name)
        {
            if (string.IsNullOrEmpty(Name))
                 throw new ArgumentNullException("Invalid Name");
            
            var subscription = await _app.Associations.SingleOrDefaultAsync(x=>x.Name == Name);
            if(subscription is null)
                 throw new Exception("Assocition Not Found");

            _app.Associations.Remove(subscription);
            var deletion = _app.SaveChanges();
            return deletion > 0 ? "Delete Successfuly" : "Invalid Deleted";
        }

        public  async ValueTask<List<string>> GetAllConsumerThatParticipantInAssociations()
        {
            var user = await _app.users.Where(x=>x.SubScriptions.Any()).ToListAsync();
            if (user is null)
                throw new Exception("You Not Have Any User is Participant in Ant Association");
               
            var userInAnyAssociation = user.Select(x=>x.UserName).ToList();
            return userInAnyAssociation!;
        }

        public async ValueTask<string> GetCollectorForCurrentMonth(string associationId)
        {
            if (string.IsNullOrEmpty(associationId))
                throw new ArgumentNullException("Invalid Name");

            var association = await _app.Associations.Include(x=>x.Users).SingleOrDefaultAsync(x => x.Name == associationId);
            if (association is null)
                throw new Exception("Assocition Not Found");
                
            var collector = await _app.users.SingleOrDefaultAsync(x=>x.Id == association.Collector);
            return collector.UserName!;

        }

        public async ValueTask<Association> GetAssociationByName(string subscriptionId)
        {

            if (string.IsNullOrEmpty(subscriptionId))
                throw new ArgumentNullException("Invalid Name");

            var association = await _app.Associations.SingleOrDefaultAsync(x => x.Name == subscriptionId);
            if (association is null)
                throw new Exception("Assocition Not Found");
            return association!;
        }

        public async ValueTask<List<string>> GetAssociationConsumerByName(string subscriptionName)
        {

            if (string.IsNullOrEmpty(subscriptionName))
                throw new ArgumentNullException("Invalid Name");

            var association = await _app.Associations.Include(x=>x.Users).SingleOrDefaultAsync(x => x.Name == subscriptionName);
            if (association is null)
                throw new Exception("Assocition Not Found");
            
            var consumers = association.Users.Select(x=>x.UserName).ToList();
            return  consumers!;

        }

        public async ValueTask<List<Association>> PaginatSubscriptions(int pageSize, int pageNumber)
        {
            if (pageSize < 0 || pageNumber < 0)
                throw new Exception("Invalid Data");

            var association = await _app.Associations.ToListAsync();
            if(association.Count() == 0)
                throw new Exception("Association List is Empty");

            var associationNumbers = association.Count();
            var requirePages = associationNumbers / pageSize;

            var skipfor = (pageNumber-1) * (pageSize);
            return association.Skip(skipfor).Take(pageSize).ToList();

        }

        public async ValueTask<string> UpdateSubscriptionAsync(Association newSubscription)
        {
            if (newSubscription is null)
                throw new ArgumentNullException("Invalid Data");

            var association = await _app.Associations.SingleOrDefaultAsync(x=>x.Name == newSubscription.Name);
            if (newSubscription is null)
                throw new Exception("Assocition Not Found");

            _app.Associations.Update(newSubscription);
            var updating = _app.SaveChanges();
            return updating > 0 ? "Updated Successfuly" : "Invalid Update";
        }
    }
}