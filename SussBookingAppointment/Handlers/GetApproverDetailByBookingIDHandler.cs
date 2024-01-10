using MediatR;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;
using SussBookingAppointment.Services;

public class GetApproverDetailByBookingIDHandler : IRequestHandler<GetApproverDetailByBookingIDQuery, ApproverDOM>
{
    private readonly IApproverRepository _approverRepositry;
    private readonly IEncryptionService _encryptionServices;
    public GetApproverDetailByBookingIDHandler(IEncryptionService encryptionServices, IApproverRepository approverRepositry)
    {

        _encryptionServices = encryptionServices; 
        _approverRepositry = approverRepositry;
    }

    async Task<ApproverDOM> IRequestHandler<GetApproverDetailByBookingIDQuery, ApproverDOM>.Handle(GetApproverDetailByBookingIDQuery request, CancellationToken cancellationToken)
    {
        ApproverDOM approverDOM = await _approverRepositry.GetApproverDetailByBookingID(_encryptionServices.DecryptValue(request.BookingID));
        return approverDOM;
    }
}