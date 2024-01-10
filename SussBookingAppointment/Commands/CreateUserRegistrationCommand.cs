using MediatR;
using SUSS.DOM.Entities;

namespace SussBookingAppointment.Commands
{
    public record CreateUserRegistrationCommand(UserRegistration UserRegistration) : IRequest<int>;
    
}
