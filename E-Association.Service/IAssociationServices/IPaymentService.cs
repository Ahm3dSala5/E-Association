using Domain.Entities.Business;
using E_Association.Infrastructure.Domain.DTOs.Payments;

namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface IPaymentService
    {
        ValueTask<string> StartPaymentAsync(Guid userId,decimal amount,Guid associationId);
        ValueTask<string> UpdatePaymentAsync(UpdatePaymentDTO payment);
        ValueTask<string> CancellationPayment(Guid userId);
        ValueTask<List<Payment>> GetUserPayments(Guid userId);
        ValueTask<List<Payment>> GetAssociationPayment(string associationName);
    }
}
