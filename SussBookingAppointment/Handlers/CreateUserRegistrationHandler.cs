using MediatR;
using SUSS.DAL.Repositories;
using SussBookingAppointment.Commands;

namespace SussBookingAppointment.Handlers
{
    public class CreateUserRegistrationHandler : IRequestHandler<CreateUserRegistrationCommand, int>
    {
        private readonly IUserRepositry _userRepositry;
        public CreateUserRegistrationHandler(IUserRepositry userRepositry)
        {
            _userRepositry = userRepositry;
        }
        public async Task<int> Handle(CreateUserRegistrationCommand request, CancellationToken cancellationToken)
        {
            return await _userRepositry.CreateUser(request.UserRegistration);
        }
    }
}
