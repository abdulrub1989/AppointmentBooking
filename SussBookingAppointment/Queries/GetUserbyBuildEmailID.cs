using MediatR;
using SussBookingAppointment.ViewModel;

namespace SussBookingAppointment.Queries
{
    public record GetUserbyBuildEmailID(string BuildEmailID) : IRequest<FormDViewModel>;
}
