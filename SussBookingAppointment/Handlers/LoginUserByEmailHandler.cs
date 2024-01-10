using MediatR;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;
using SussBookingAppointment.Queries;

namespace SussBookingAppointment.Handlers
{
    public class LoginUserByEmailHandler : IRequestHandler<LoginUserByEmailQuery, UsersDetail>
    {
        private readonly ILoginRepository _loginRepository;
        public LoginUserByEmailHandler(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<UsersDetail> Handle(LoginUserByEmailQuery request, CancellationToken cancellationToken)
        {
           UsersDetail usersDetail = await _loginRepository.ValidateUser(request.UsersDetail.EmailAddress,request.UsersDetail.Password);
           return usersDetail;
        }
    }
}
