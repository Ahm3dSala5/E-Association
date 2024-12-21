using Domain.Entities.Business;
using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.Helpers.MailHelper;
using E_Association.Service.IAssociationServices.IBalanceServices;
using E_Association.Service.IAssociationServices.IEmailSender;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.BalanceServices
{
    public class NotificationService : INotificationService
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;
        public NotificationService(AppDbContext context, IEmailSender emailSender = null)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public async ValueTask<string> CreateNotification(string contentMessage)
        {
            var _notification = new Notifications()
            {
                Message = contentMessage,
                CreatedAt = DateTime.Now,
            };

            await _context.Notifications.AddAsync(_notification);
            var creation = _context.SaveChanges();
            return creation > 0 ? "Added Successfuly" : "Invalid Operation";
        }

        public async ValueTask<string> DeleteNotification(Guid notificationId)
        {
            var _notification = await _context.Notifications.FindAsync(notificationId);
            var deletion = _context.SaveChanges();
            return deletion > 0 ? "Added Successfuly" : "Invalid Operation";
        }

        public async ValueTask<List<Notifications>> GetUserNotifications(string useremail)
        {
            if (useremail is null)
                throw new ArgumentException("Invalid Email");

            var user = await _context.users.Include(x => x.Notifications)
                      .SingleOrDefaultAsync(x => x.Email == useremail);
            if (user is null)
                throw new Exception("User Not Found");

            var notifications = user.Notifications.ToList();
            return notifications;
        }

        public async ValueTask<List<Notifications>> GetSubscriptionNotification(string subscriptionName)
        {

            if (subscriptionName is null)
                throw new ArgumentException("Invalid Subscription Name");

            var subscription = await _context.Associations.Include(x => x.Notifications)
                              .SingleOrDefaultAsync(x => x.Name == subscriptionName);

            if (subscription is null)
                throw new Exception("Subscription Not Found");

            var notifications = subscription.Notifications.ToList();
            return notifications;
        }

        public async ValueTask<string> SendToAllUsersAsync(string title, string message)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title or message is empty");

            var users = await _context.Users.ToListAsync();
            if (users.Count() == 0)
                throw new ArgumentNullException("users list is empty");

            var emails = users.Select(x => x.Email).ToList();
            return await MailHelper.SendMailToGroup(_emailSender, emails!, title, message);
        }

        public async ValueTask<string> SendToSubscriptionUserAsync(string title, string message, string subscriptionName)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title or message is empty");

            var subscription = _context.Associations.Include(x => x.Users).SingleOrDefault(x => x.Name == subscriptionName);
            var emails = subscription!.Users.Select(x => x.Email).ToList();

            if (emails.Count() == 0)
                throw new ArgumentNullException("subscription is empty");

            return await MailHelper.SendMailToGroup(_emailSender, emails!, title, message);
        }

        public async ValueTask<string> SendToUserAsync(string title, string message, Guid userId)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title or message is empty");

            var user = await _context.users.FindAsync(userId);
            if (user is null)
                throw new ArgumentNullException("Invalid Email");

            return await MailHelper.SendMailToOne(_emailSender, user.Email!, title, message);
        }

        public async ValueTask<string> UpdateNotification(Guid notificationId, string newContentMessage)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification is null)
                throw new Exception("Notification NotFound");

            notification.Message = newContentMessage;
            int updateresult = _context.SaveChanges();
            return updateresult > 0 ? "Updated Successfuly" : "Invalid Update";
        }
    }
}
