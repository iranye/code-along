namespace LogicSolver.Web.Services
{
    public interface IEmailService
    {
        void SendMail(string fromEmail, string toEmail, string subject, string body);
    }
}
