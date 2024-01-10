using SUSS.DOM.Entities;

namespace SUSS.DAL.Repositories
{
    public interface IApproverRepository
    {
        Task<ApproverDOM> GetApproverDetailByBookingID(string BookingID);
        Task<int> UpdateApproveRequest(Approver approver);
    }
}
