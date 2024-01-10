using Dapper;
using Microsoft.Extensions.Configuration;
using SUSS.DOM.Entities;
using System.Data;

namespace SUSS.DAL.Repositories
{
    public class UserRepositry : BaseRepository, IUserRepositry
    {
        private readonly ICommonRepository _commonRepositry;
        private readonly ICounsellingType _counsellingType;
        public UserRepositry(IConfiguration configuration, ICounsellingType counsellingType, ICommonRepository commonRepositry) : base(configuration)
        {
            _counsellingType = counsellingType;
            _commonRepositry = commonRepositry;
        }

        async Task<UsersDetail> IUserRepositry.GetUserbyBuildEmailID(string BuildEmailID)
        {
            var query = DBConstant.GetUsersDetailByMyEmailID;
            using (var connection = CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("MyEmailID", BuildEmailID);
                parameters.Add("Error_Code", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("Error_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                UsersDetail user = await connection.QuerySingleOrDefaultAsync<UsersDetail>(query, parameters, commandType: CommandType.StoredProcedure);
                user = (user == null) ? new UsersDetail() : user;
                user.Error_Message = parameters.Get<string>("Error_Message");
                user.Error_Code = parameters.Get<int?>("Error_Code");
                return user;
            }
        }
        async Task<int> IUserRepositry.CreateUser(UserRegistration RegistrationModel)
        {
            RegistrationModel.CounsellingID = _counsellingType.GetCounsellingType();
            UserRegistration result = await Task.FromResult(_commonRepositry.Insert<UserRegistration>(DBConstant.CreateFormD
               , RegistrationModel,
               commandType: CommandType.StoredProcedure));
            return result.ID;
        }
        Task<FormM> IUserRepositry.GetUserbyID(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
