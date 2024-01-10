namespace SussBookingAppointment.Services
{
    public interface IHttpContextAccessorService
    {
        public void SetCurrentUserEmail(string key, string val);
        public string? GetCurrentUserEmail(string key);
        public void SetInBuildEmailCookie(string val);
        public void SetInCookie(string key, string val);
        public string GetInCookie(string key);
        public string GetInBuildEmailCookie();
    }
}
