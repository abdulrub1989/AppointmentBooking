using MediatR;
using SUSS.DOM.Entities;

namespace SussBookingAppointment.Commands
{
    public record CreateBookingCommand(FormM Form_M) : IRequest<int>;
}
