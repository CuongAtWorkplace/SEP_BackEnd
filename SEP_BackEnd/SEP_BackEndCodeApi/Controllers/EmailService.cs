using System.Net;
using System.Net.Mail;

public class EmailService
{
    private readonly string smtpServer = "your-smtp-server.com";
    private readonly int smtpPort = 587; // Thay thế bằng cổng SMTP của bạn
    private readonly string smtpUsername = "your-smtp-username";
    private readonly string smtpPassword = "your-smtp-password";

    public void SendEmail(string to, string subject, string body)
    {
        using (var client = new SmtpClient(smtpServer))
        {
            client.Port = smtpPort;
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            client.EnableSsl = true;

            var message = new MailMessage
            {
                From = new MailAddress("ngobacuong2211@gmail.com"), // Điền email của bạn
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            message.To.Add(to);

            client.Send(message);
        }
    }
}
