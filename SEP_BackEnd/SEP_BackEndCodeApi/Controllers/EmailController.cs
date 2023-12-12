using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web;
using System.Net.Mail;

namespace SEP_BackEndCodeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private static List<VerificationCode> temporaryCodes = new List<VerificationCode>();

        [HttpPost]
        public IActionResult SendEmail([FromBody] EmailRequest request)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SEP_G63", "ngobacuong2211@gmail.com"));
            message.To.Add(new MailboxAddress("", request.To));
            message.Subject = request.Subject;

            var bodyBuilder = new BodyBuilder();

            // Tạo mã ngẫu nhiên
            string randomCode = GenerateRandomCode();

            // Lưu mã ngẫu nhiên vào danh sách tạm thời
            temporaryCodes.Add(new VerificationCode { Email = request.To, Code = randomCode });

            // Nội dung của form HTML
            bodyBuilder.HtmlBody = $@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Change Password</title>
                </head>
                <body>
                    <h2>Change Password</h2>
                    <form id=""passwordForm"">
                        <label for=""email"">Your code:</label>
                        <!-- Truyền mã ngẫu nhiên vào một trường ẩn -->
                        <input type=""hidden"" id=""randomCode"" name=""randomCode"" value=""{HttpUtility.HtmlEncode(randomCode)}"">
                        <p><span id=""randomCodeText"">{HttpUtility.HtmlEncode(randomCode)}</span></p>
                        <br>
                  
                    </form>
                    <p>If you did not request a password change, please ignore this email.</p>

                    <!-- Thêm một thẻ div để hiển thị thông báo -->
                    <div id=""resultMessage""></div>
                </body>
                </html>
            ";

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("ngobacuong2211@gmail.com", "utegedatcyktwyuj");

                    client.Send(message);
                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu cần
                    return BadRequest($"Email sent failed. Error: {ex.Message}");
                }
            }

            return Ok("Email sent successfully");
        }

        [HttpPost("confirm-code")]
        public IActionResult ConfirmCode([FromBody] VerificationRequest verificationRequest)
        {
            var existingCode = temporaryCodes.Find(code => code.Email == verificationRequest.To && code.Code == verificationRequest.Code);

            if (existingCode != null)
            {
                // Mã xác nhận hợp lệ, thực hiện xử lý xác nhận tại đây

                // Sau khi xác nhận, bạn có thể loại bỏ mã ngẫu nhiên khỏi danh sách
                temporaryCodes.Remove(existingCode);

                return Ok("Verification successful");
            }

            return BadRequest("Invalid verification code");
        }

        private string GenerateRandomCode()
        {
            // Logic để tạo mã ngẫu nhiên
            // Trong trường hợp này, tạo một mã ngẫu nhiên đơn giản
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }

    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        // Bạn có thể thêm các trường khác như cần thiết
    }

    public class VerificationCode
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }

    public class VerificationRequest
    {
        public string To { get; set; }
        public string Code { get; set; }
    }
}
 