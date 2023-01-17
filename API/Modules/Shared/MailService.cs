using API.Modules.Shared.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace API.Modules.Shared;

public class MailService : IMailService
{
    private readonly MailSettings mailSettings;

    public MailService(IOptions<MailSettings> mailSettings)
    {
        this.mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body, List<IFormFile>? attachments = null)
    {
        try
        {
            MimeMessage email = new();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            BodyBuilder builder = new();

            if(attachments != null)
            {
                byte[] fileBytes;
                foreach(var file in attachments)
                {
                    if(file.Length > 0)
                    {
                        using(var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();

            SmtpClient smtp = new();
            await smtp.ConnectAsync(this.mailSettings.Host, this.mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(this.mailSettings.Mail, this.mailSettings.Password);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
        catch(Exception ex)
        {
            throw new Exception("Un probléme est survenur lors de l'envoie de mail: MailService/SendEmailAsync", ex);
        }
    }
}
