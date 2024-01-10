using Microsoft.AspNetCore.DataProtection;
namespace SussBookingAppointment.Services
{
    public class EncryptionService: IEncryptionService
    {
        private IDataProtectionProvider _provider;
        private const string Purpose = "CustomData CookieRetain";
        public EncryptionService(IDataProtectionProvider provider)
        {
            _provider = provider;
        }
        public string EncryptValue(string message)
        {
            var protector = _provider.CreateProtector(Purpose);
            return protector.Protect(message);
        }
        public string DecryptValue(string message)
        {
            var protector = _provider.CreateProtector(Purpose);
            return protector.Unprotect(message);
        }
    }
}
