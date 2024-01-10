using MediatR;
using SUSS.DOM.Entities;

namespace SussBookingAppointment.Queries
{
    public record GetUserDetailsFormNQuery(string Email) : IRequest<FormN>;
}
