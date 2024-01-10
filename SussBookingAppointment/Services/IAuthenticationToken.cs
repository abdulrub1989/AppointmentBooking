namespace SussBookingAppointment.Services
{
    public interface IAuthenticationServices
    {
        public void SetToken(AuthenticationToken token);
        public AuthenticationToken GetToken();

    }
}
