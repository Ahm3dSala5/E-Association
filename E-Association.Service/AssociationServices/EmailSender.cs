using E_Association.Service.IAssociationServices.IEmailSender;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace E_Association.Service.AssociationServices.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;

        public EmailSender(IConfiguration _config)
        {
            configuration = _config ?? throw new ArgumentNullException(nameof(_config));
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Recipient email cannot be null or empty.", nameof(email));

            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentException("Email subject cannot be null or empty.", nameof(subject));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Email message cannot be null or empty.", nameof(message));

            string smtpServer = configuration["SMTP:Server"]!;
            string smtpPortString = configuration["SMTP:Port"]!;
            string smtpUsername = configuration["SMTP:Username"]!;
            string smtpPassword = configuration["SMTP:Password"]!;

            if (string.IsNullOrWhiteSpace(smtpServer) || string.IsNullOrWhiteSpace(smtpPortString) ||
                string.IsNullOrWhiteSpace(smtpUsername) || string.IsNullOrWhiteSpace(smtpPassword))
            {
                throw new InvalidOperationException("SMTP configuration is incomplete. Please check your appsettings.json.");
            }

            if (!int.TryParse(smtpPortString, out int smtpPort))
            {
                throw new InvalidOperationException("SMTP port must be a valid integer.");
            }

            using (var client = new SmtpClient(smtpServer, smtpPort))
            {
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUsername),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true // Use true if your email body contains HTML
                };

                mailMessage.To.Add(email);

                try
                {
                    await client.SendMailAsync(mailMessage);
                }
                catch (SmtpException ex)
                {
                    throw new InvalidOperationException($"Email sending failed: {ex.Message}", ex);
                }
            }
        }
    }
}
