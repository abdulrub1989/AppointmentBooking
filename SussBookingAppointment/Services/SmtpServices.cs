using MailKit.Security;
using MimeKit;
using SUSS.DOM.EmailEnitiies;
using SussBookingAppointment.Configuration;
using System.Text;

namespace SussBookingAppointment.Services
{
    public class SmtpServices : ISmtpServices
    {
        private IConfiguration ConfigRoot;
        private readonly ILogger<SmtpServices> _logger;
        public SmtpServices(IConfiguration configRoot, ILogger<SmtpServices> logger)
        {
            ConfigRoot = configRoot;
            _logger = logger;
        }
        MimeMessage ISmtpServices.SendEmailAsync(string email, string type, string bookingID)
        {
            EmailTemplate emailTemplate = new EmailTemplate();
            bool testMode = (ConfigRoot.GetSection("EmailConfig:IsTest").Value == "Yes");

            string toAddresses = email;
            string bccAddresses = emailTemplate.BCC_recipients;
            string fromAddress = ConfigRoot.GetSection("EmailConfig:FromAddress").Value;
            if (testMode)
            {
                toAddresses = ConfigRoot.GetSection("EmailConfig:TestToAddress").Value;
                bccAddresses = null;
            }
            if (type.Equals(Constants.EmailType_DynamicsCase))
            {
                toAddresses = ConfigRoot.GetSection("EmailConfig:ToAddressDynamicsCase").Value;
                fromAddress = email; //dynamics uses the fromaddress to map the contact as the student.
            }

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Adminstrator", ConfigRoot.GetSection("EmailConfig:FromAddress").Value));
            foreach (var address in toAddresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mailMessage.To.Add(new MailboxAddress(address, address));
            }
            if (!String.IsNullOrEmpty(bccAddresses))
            {
                foreach (var address in bccAddresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mailMessage.Bcc.Add(new MailboxAddress(address, address));
                }
            }

            mailMessage.From.Add(new MailboxAddress(fromAddress, fromAddress));
            mailMessage.Subject = "Online Counselling Approer";
            StringBuilder body = new StringBuilder("This");
            emailTemplate.HtmlBody = "Hi Staff,</br></br>This is Test mail for Online Counselling Approer</br></br><a href='https://localhost:7196/Staff/Approver/"+ bookingID + "'>Click here to approve the request</a></br></br><b>Regards</b>,</br><b>Admin-noreply</b>";
            var builder = new BodyBuilder();
            builder.HtmlBody = string.Format(emailTemplate.HtmlBody);

           
            mailMessage.Body = builder.ToMessageBody();


            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(ConfigRoot.GetSection("EmailConfig:Host").Value,
                    Convert.ToInt32(ConfigRoot.GetSection("EmailConfig:Port").Value),
                    SecureSocketOptions.None);
                smtp.Send(mailMessage);
                smtp.Disconnect(true);
            }
            return mailMessage;
        }

        async void ISmtpServices.SendEmail()
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("System", "system@test.com"));
            emailMessage.To.Add(new MailboxAddress("Dave Paquette", "dave@dave.com"));
            emailMessage.Subject = "This is a test";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Important message</h1><p>This is from the system</p>";
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                var secureSocketOptions = SecureSocketOptions.None;
                client.Connect("localhost", 25, secureSocketOptions);
                await client.SendAsync(emailMessage);
                client.Disconnect(true);
            }
        }

        MimeMessage ISmtpServices.SendApproveEmailAsync(string email, string type, string bookingID)
        {
            EmailTemplate emailTemplate = new EmailTemplate();
            bool testMode = (ConfigRoot.GetSection("EmailConfig:IsTest").Value == "Yes");

            string toAddresses = email;
            string bccAddresses = emailTemplate.BCC_recipients;
            string fromAddress = ConfigRoot.GetSection("EmailConfig:FromAddress").Value;
            if (testMode)
            {
                toAddresses = ConfigRoot.GetSection("EmailConfig:TestToAddress").Value;
                bccAddresses = null;
            }
            if (type.Equals(Constants.EmailType_DynamicsCase))
            {
                toAddresses = ConfigRoot.GetSection("EmailConfig:ToAddressDynamicsCase").Value;
                fromAddress = email; //dynamics uses the fromaddress to map the contact as the student.
            }

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Adminstrator", ConfigRoot.GetSection("EmailConfig:FromAddress").Value));
            foreach (var address in toAddresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mailMessage.To.Add(new MailboxAddress(address, address));
            }
            if (!String.IsNullOrEmpty(bccAddresses))
            {
                foreach (var address in bccAddresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mailMessage.Bcc.Add(new MailboxAddress(address, address));
                }
            }

            mailMessage.From.Add(new MailboxAddress(fromAddress, fromAddress));
            mailMessage.Subject = "Staff Approved Online Counselling Request";
            StringBuilder body = new StringBuilder("This");
            emailTemplate.HtmlBody = "Hi Requester,</br></br>Your Request Has Been Approved.</br></br><b>Admin-noreply</b>";
            var builder = new BodyBuilder();
            builder.HtmlBody = string.Format(emailTemplate.HtmlBody);


            mailMessage.Body = builder.ToMessageBody();


            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(ConfigRoot.GetSection("EmailConfig:Host").Value,
                    Convert.ToInt32(ConfigRoot.GetSection("EmailConfig:Port").Value),
                    SecureSocketOptions.None);
                smtp.Send(mailMessage);
                smtp.Disconnect(true);
            }
            return mailMessage;
        }

        MimeMessage ISmtpServices.SendRejectedEmailAsync(string email, string type, string bookingID)
        {
            EmailTemplate emailTemplate = new EmailTemplate();
            bool testMode = (ConfigRoot.GetSection("EmailConfig:IsTest").Value == "Yes");

            string toAddresses = email;
            string bccAddresses = emailTemplate.BCC_recipients;
            string fromAddress = ConfigRoot.GetSection("EmailConfig:FromAddress").Value;
            if (testMode)
            {
                toAddresses = ConfigRoot.GetSection("EmailConfig:TestToAddress").Value;
                bccAddresses = null;
            }
            if (type.Equals(Constants.EmailType_DynamicsCase))
            {
                toAddresses = ConfigRoot.GetSection("EmailConfig:ToAddressDynamicsCase").Value;
                fromAddress = email; //dynamics uses the fromaddress to map the contact as the student.
            }

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Adminstrator", ConfigRoot.GetSection("EmailConfig:FromAddress").Value));
            foreach (var address in toAddresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                mailMessage.To.Add(new MailboxAddress(address, address));
            }
            if (!String.IsNullOrEmpty(bccAddresses))
            {
                foreach (var address in bccAddresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mailMessage.Bcc.Add(new MailboxAddress(address, address));
                }
            }

            mailMessage.From.Add(new MailboxAddress(fromAddress, fromAddress));
            mailMessage.Subject = "Staff Rejected Online Counselling Request";
            StringBuilder body = new StringBuilder("This");
            emailTemplate.HtmlBody = "Hi Requester,</br></br>Your Request Has Been Rejected.</br></br><b>Admin-noreply</b>";
            var builder = new BodyBuilder();
            builder.HtmlBody = string.Format(emailTemplate.HtmlBody);


            mailMessage.Body = builder.ToMessageBody();


            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(ConfigRoot.GetSection("EmailConfig:Host").Value,
                    Convert.ToInt32(ConfigRoot.GetSection("EmailConfig:Port").Value),
                    SecureSocketOptions.None);
                smtp.Send(mailMessage);
                smtp.Disconnect(true);
            }
            return mailMessage;
        }
    }
}
