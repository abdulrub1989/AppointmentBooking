namespace SussBookingAppointment.Services
{
    public interface IEncryptionService
    {
        string DecryptValue(string message);
        string EncryptValue(string message);
    }
}
