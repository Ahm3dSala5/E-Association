using Domain.Entities.Business;

namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface IAssociationService
    {
        ValueTask<string> CreateAssociationAsync(Association subscription);
        ValueTask<string> DeleteSubscriptionAsync(string Name);
        ValueTask<string> ApplyToAssociation(string applicantUserName, string associationName, int getCashInMonth);
        ValueTask<string> UpdateSubscriptionAsync(Association newSubscription);
        ValueTask<Association> GetAssociationByName(string subscriptionId);
        ValueTask<List<Association>> PaginatSubscriptions(int pageSize, int pageNumber);
        ValueTask<string> GetCollectorForCurrentMonth(string associationId);
        ValueTask<List<string>> GetAllConsumerThatParticipantInAssociations();
        ValueTask<List<string>> GetAssociationConsumerByName(string subscriptionName);
    }
}
