using SUSS.DOM.Entities;

namespace SUSS.DAL.Repositories
{
    public interface IUserRepositry
    {
        Task<UsersDetail> GetUserbyBuildEmailID(string BuildEmailID);
        Task<FormM> GetUserbyID(int userId);
        Task<int> CreateUser(UserRegistration RegistrationModel);
    }
}
