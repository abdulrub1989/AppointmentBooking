using MediatR;
using SUSS.DOM.Entities;

namespace SussBookingAppointment.Queries
{
    public record GetUserDetailsByUserIdQuery(string emailId): IRequest<FormM>;
}
