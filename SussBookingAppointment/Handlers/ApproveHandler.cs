using MediatR;
using SUSS.DAL.Repositories;
using SUSS.DOM.Entities;
using SussBookingAppointment.Services;

namespace SussBookingAppointment.Handlers
{
    public class ApproveHandler : IRequestHandler<ApproveCommand, int>
    {
        private readonly IApproverRepository _approverRepositry;
        private readonly IEncryptionService _encryptionServices;
        private readonly ISmtpServices _smtpServices;
        public ApproveHandler(IEncryptionService encryptionServices, IApproverRepository approverRepositry, ISmtpServices smtpServices)
        {
            _smtpServices = smtpServices;
            _encryptionServices = encryptionServices;
            _approverRepositry = approverRepositry;
        }
        async Task<int> IRequestHandler<ApproveCommand, int>.Handle(ApproveCommand request, CancellationToken cancellationToken)
        {
            Approver approver = new Approver()
            {
                ApproverID = _encryptionServices.DecryptValue(request.approver.ApproverID),
                UserID = _encryptionServices.DecryptValue(request.approver.UserID),
                Status = request.approver.Status
            };
            int result = await _approverRepositry.UpdateApproveRequest(approver);
            if (request.approver.Status == "2")
            {
                _smtpServices.SendApproveEmailAsync("Requester@espire.com", "Dev Test Email", "Approved");
            }
            else if(request.approver.Status == "3")
            {
                _smtpServices.SendRejectedEmailAsync("Requester@espire.com", "Dev Test Email", "Rejected");
            }
            return result;

        }
    }
}
