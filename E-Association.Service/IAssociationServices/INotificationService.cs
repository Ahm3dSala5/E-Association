using Domain.Entities.Business;

namespace E_Association.Service.IAssociationServices.IBalanceServices
{
    public interface INotificationService
    {
        ValueTask<string> CreateNotification(string contentMessage);
        ValueTask<string> SendToUserAsync(string title, string message, Guid userId);
        ValueTask<string> SendToAllUsersAsync(string title, string message);
        ValueTask<string> SendToSubscriptionUserAsync(string title, string message, string subscriptionCode);
        ValueTask<string> UpdateNotification(Guid notificationId, string newMessage);
        ValueTask<string> DeleteNotification(Guid notificationId);
        ValueTask<List<Notifications>> GetUserNotifications(string userId);
        ValueTask<List<Notifications>> GetSubscriptionNotification(string subscriptionId);
    }
}
