using MediatR;
using SUSS.DOM.Entities;

namespace SussBookingAppointment.Queries
{
    public record LoginUserByEmailQuery(LoginModel UsersDetail) : IRequest<UsersDetail>;
   
}
