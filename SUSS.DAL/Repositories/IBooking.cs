using SUSS.DOM.Entities;

namespace SUSS.DAL.Repositories
{
    public interface IBooking
    {
        Task<int> CreateBooking(FormM RegistrationModel);
    }
}
