using MediatR;
using SUSS.DOM.Entities;

public record GetApproverDetailByBookingIDQuery(string BookingID) : IRequest<ApproverDOM>;