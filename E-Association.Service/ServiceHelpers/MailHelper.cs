using E_Association.Service.IAssociationServices.IEmailSender;

namespace E_Association.Service.Helpers.MailHelper
{
    public static class MailHelper
    {
        public static async Task<string> SendMailToGroup(IEmailSender emailSender, List<string> emails, string emailTitle, string message)
        {
            if (emails.Count() == 0)
                throw new ArgumentNullException("Emails List is Empty");

            foreach (var email in emails)
                await emailSender.SendEmailAsync(email, emailTitle, message);

            return "Mails Sended Successfuly";

        }
        public static async Task<string> SendMailToOne(IEmailSender emailSender, string email, string emailTitle, string message)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("Email Not Found");

            await emailSender.SendEmailAsync(email, emailTitle, message);
            return "Mail Sended Successfuly";
        }
    }
}
