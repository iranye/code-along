namespace LogicSolver.Web.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> logger;

        public EmailService(ILogger<EmailService> logger)
        {
            this.logger = logger;
        }

        public void SendMail(string fromEmail, string toEmail, string subject, string body)
        {
            logger.LogInformation("Email Sent From: {FromEmail} To: {ToEmail} Subject: {Subject} Body: {Body}",
                fromEmail, toEmail, subject, body);
        }
    }
}
