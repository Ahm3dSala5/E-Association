namespace E_Association.Service.IAssociationServices.IEmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
