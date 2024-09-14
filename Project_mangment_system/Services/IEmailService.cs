namespace Project_management_system.Services
{
    public interface IEmailService
    {
        public  Task SendEmailAsync(string mailTo, string subject, string body);
    }
}
