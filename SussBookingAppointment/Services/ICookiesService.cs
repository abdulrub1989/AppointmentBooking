namespace SussBookingAppointment.Services
{
    public interface ICookiesService
    {
        public void SetInBuildEmailCookie(string val, int? expireTime, HttpResponse Response);
        public void SetInCookie(string key,string val, int? expireTime, HttpResponse Response);
        public string GetInBuildEmailCookie(HttpRequest Request);
        public string GetInCookie(string key, HttpRequest Request);
    }
}
