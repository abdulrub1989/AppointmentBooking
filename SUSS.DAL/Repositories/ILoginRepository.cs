using SUSS.DOM.Entities;

namespace SUSS.DAL.Repositories
{
    public interface ILoginRepository: IGenericRepository<UsersDetail>
    {
        //Task<List<UsersDetail>> GetAllUser();
        //Task<UsersDetail> GetUserByEmailId(string Email);
        Task<UsersDetail> ValidateUser(string Email, string Password);
       // Task<bool> UserExist(string Email);
    }
}
