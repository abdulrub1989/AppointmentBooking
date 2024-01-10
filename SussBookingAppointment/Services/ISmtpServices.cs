using MimeKit;
namespace SussBookingAppointment.Services
{
    public interface ISmtpServices
    {
        MimeMessage SendEmailAsync(string email, string type,string bookingID);
        MimeMessage SendApproveEmailAsync(string email, string type, string bookingID);
        MimeMessage SendRejectedEmailAsync(string email, string type, string bookingID);
        void SendEmail();
    }
}
