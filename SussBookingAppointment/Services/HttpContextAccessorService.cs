using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace SussBookingAppointment.Services
{
    //services.AddHttpContextAccessor();
   // var sessionValue = _httpContextAccessor.HttpContext.Session.GetString("Key");

    public class HttpContextAccessorService: IHttpContextAccessorService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private readonly IEncryptionService _encryptionService;
        public HttpContextAccessorService(IHttpContextAccessor httpContextAccessor, IEncryptionService encryptionService)
        {
            _httpContextAccessor = httpContextAccessor;
            _encryptionService = encryptionService;
            _session = _httpContextAccessor.HttpContext.Session;
        }
        public void SetCurrentUserEmail(string key,string val)
        {
            _session.SetString(key, val);
        }
        public string? GetCurrentUserEmail(string key)
        {
           return _session.GetString(key);
        }
        public void SetInBuildEmailCookie(string val)
        {
            _session.SetString("BuildEmail", _encryptionService.EncryptValue(val));
        }
        public void SetInCookie(string key,string val)
        {
            _session.SetString(key, _encryptionService.EncryptValue(val));
        }
        public string GetInCookie(string key)
        {
            if (_session.TryGetValue(key, out var value))
            {
                var valueString = Encoding.UTF8.GetString(value);
                return _encryptionService.DecryptValue(Convert.ToString(valueString));
            }
            return "";
        }
        public string GetInBuildEmailCookie()
        {
            if (_session.TryGetValue("BuildEmail", out var value))
            {
                var valueString = Encoding.UTF8.GetString(value);
                return _encryptionService.DecryptValue(Convert.ToString(valueString));
            }
            return "";
        }
    }
}
