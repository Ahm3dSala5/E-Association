using Domain.Entities.Business;
using E_Association.Core.Domain.Enums;
using E_Association.Infrastructure.Domain.DTOs.Payments;
using E_Association.Infrastructure.Presitence.Data;
using E_Association.Service.IAssociationServices.Userservice;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.Userservice
{
    public class PaymentService : MainService<Payment> , IPaymentService
    {
        private AppDbContext _app;
        public PaymentService(AppDbContext app) :base(app)
        {
            this._app = app;
        }

        public async  ValueTask<string> CancellationPayment(Guid paymentId)
        {
            if (paymentId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var payment = await _app.Payments.FindAsync(paymentId);
            if (payment is null)
                throw new ArgumentNullException("Payment Not Found");

            _app.Payments.Remove(payment);
            int deletion = await  _app.SaveChangesAsync();
            return deletion > 0 ? "Sccessfuly" : "Invalid operation";
        }

        public async ValueTask<List<Payment>> GetAssociationPayment(string associationName)
        {
            if (associationName.Length == 0)
                throw new ArgumentNullException("Invalid Data");

            var association =await _app.Associations.Include(x=>x.Payments).SingleOrDefaultAsync(x=>x.Name == associationName);
            if (association is null)
                throw new ArgumentNullException("association Not Found");

            var payments = association.Payments.ToList();
            if (payments is null)
                throw new ArgumentNullException("association Not Have any payments");

            return payments;
        }

        public async ValueTask<List<Payment>> GetUserPayments(Guid userId)
        {
            if(userId == Guid.Empty)
                throw new ArgumentNullException("Invalid Data");

            var user = await _app.users.Include(x => x.Payments).SingleOrDefaultAsync(x => x.Id == userId);
            if (user is null)
                throw new Exception("User Not Found");

            var paymets = user.Payments.ToList();
            if (paymets.Count() == 0 )
                throw new Exception("User Not Have any Payments");
            return paymets;
        }

        public async ValueTask<string> StartPaymentAsync(Guid userId, decimal _amount, Guid associationId)
        {
            if (userId == Guid.Empty || associationId == Guid.Empty || _amount <= 0)
                throw new ArgumentNullException("Invalid Data");

            var user = await _app.users.Include(x=>x.Balance).SingleOrDefaultAsync(x=>x.Id == userId);
            if(user is null)
                throw new Exception("User Not Found");

            var asspication = await _app.Associations.FindAsync(associationId);
            if (asspication is null)
                throw new Exception("asspication Not Found");

            if(user.Balance.Amount < _amount)
                throw new Exception("User Not Have enough Money");
            var paymentResult = 0;
            using (var transaction = await _app.Database.BeginTransactionAsync())
            {
                user.Balance.Amount -= _amount;
                asspication.TotalBalance += _amount;
                var payment = new Payment()
                {
                    Amount = _amount,
                    UserId = userId,
                    PaidAt = DateTime.Now,
                    Status = PaymentStatus.Paid,
                    AssociationId = associationId
                };
                await _app.Payments.AddAsync(payment);
                await transaction.CommitAsync();
                paymentResult = await _app.SaveChangesAsync();
            }
            return paymentResult > 0 ? "Sccessfuly" : "Invalid operation";
        }

        public async ValueTask<string> UpdatePaymentAsync(UpdatePaymentDTO _payment)
        {
            if (_payment is null)
                throw new ArgumentNullException("Invalid Data");

            var payment = await _app.Payments.SingleOrDefaultAsync(x => x.Id == _payment.PaymentId);
            var user = await _app.Users.Include(x=>x.Payments).SingleOrDefaultAsync(x => x.Id == _payment.UserId);
            var association = await _app.Associations.SingleOrDefaultAsync(x => x.Id == _payment.AssociationId);
            if (payment is null || user is null)
                throw new Exception("User or Payment Not Found");

           if(payment.Status == PaymentStatus.Paid)
                throw new Exception("Payment is alrady Confirmed");

            var paymentResult = 0;
            using (var transaction = await _app.Database.BeginTransactionAsync())
            {
                user.Balance.Amount -= _payment.Amount;
                association!.TotalBalance += _payment.Amount;
                var PAYMENT = new Payment()
                {
                    Amount = _payment.Amount,
                    UserId = _payment.UserId,
                    PaidAt = DateTime.Now,
                    Status = PaymentStatus.Paid,
                    AssociationId = _payment.AssociationId
                };
                _app.Payments.Attach(PAYMENT);
                await transaction.CommitAsync();
                paymentResult = await _app.SaveChangesAsync();
            }
            return paymentResult > 0 ? "Sccessfuly" : "Invalid operation";
        }
    }
}