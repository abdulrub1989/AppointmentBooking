using MediatR;
using SussBookingAppointment.ViewModel;

public record GetCunsultancyTypeQuery() : IRequest<CunsultancyTypeViewModel>;
