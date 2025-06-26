using System.Net;
using System.Net.Mail;

namespace GenieWeb.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration config, ILogger<EmailService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public void SendActivationEmail(string toEmail, string activationLink)
        {
            var smtpClient = new SmtpClient("mail5015.site4now.net")
            {
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("mailserviceagent@ittechgenie.com", "JaiKrishna@5"),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("mailserviceagent@ittechgenie.com", "ItTechGenie"),
                Subject = "Activate Your Account - ItTechGenie",
                Body = $"Hi,\n\nPlease click the link below to activate your account:\n\n{activationLink}\n\nRegards,\nItTechGenie Team",
                IsBodyHtml = false
            };

            mailMessage.To.Add(toEmail);

            try
            {
                smtpClient.Send(mailMessage);
                _logger.LogInformation($"✅ Activation email sent to {toEmail}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Failed to send activation email to {toEmail}. Error: {ex.Message}");
                throw; // Optional: let the caller handle it
            }
        }
    }
}
