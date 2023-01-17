namespace API.Modules.Shared;

public interface IMailService
{
    Task SendEmailAsync(string toEmail, string subject, string body, List<IFormFile>? attachments = null);
}
