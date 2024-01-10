namespace SussBookingAppointment.Services
{
    internal class CookiesService : ICookiesService
    {
        private readonly ILogger<CookiesService> _logger;
        private readonly IEncryptionService _encryptionService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookiesService(ILogger<CookiesService> logger,IEncryptionService encryptionService)
        {
            _logger = logger;
            _encryptionService = encryptionService;
        }
        public void SetInBuildEmailCookie(string val, int? expireTime, HttpResponse Response)
        {
            CookieOptions option = new CookieOptions
            {
                SameSite = SameSiteMode.Strict,
                HttpOnly = true
            };
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddDays(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMinutes(2);
            Response.Cookies.Append("BuildEmail", _encryptionService.EncryptValue(val), option);
        }
        public void SetInCookie(string key,string val, int? expireTime, HttpResponse Response)
        {
            CookieOptions option = new CookieOptions
            {
                SameSite = SameSiteMode.Strict,
                HttpOnly = true
            };
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddDays(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, _encryptionService.EncryptValue(val), option);
        }
        public string GetInCookie(string key, HttpRequest Request)
        {
            if (Request.Cookies[key] == null)
                return null;
            return _encryptionService.DecryptValue(Request.Cookies[key]);
        }
        public string GetInBuildEmailCookie(HttpRequest Request)
        {
            if (Request.Cookies["BuildEmail"] == null)
                return null;
            return _encryptionService.DecryptValue(Request.Cookies["BuildEmail"]);
        }
    }
}
