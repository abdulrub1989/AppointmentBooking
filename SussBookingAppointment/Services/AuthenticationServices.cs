namespace SussBookingAppointment.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly AuthenticationToken authenticationToken;
        public AuthenticationServices()
        {
            authenticationToken = new AuthenticationToken();
        }
        public AuthenticationToken GetToken()
        {
            return authenticationToken;
        }

        public void SetToken(AuthenticationToken token)
        {
            authenticationToken.token_type = token.token_type;
            authenticationToken.expires_in = token.expires_in;
            authenticationToken.ext_expires_in = token.ext_expires_in;
            authenticationToken.access_token = token.access_token;
        }
    }
}
