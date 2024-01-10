using Dapper;
using Microsoft.Extensions.Configuration;
using SUSS.DOM.Entities;
using System.Data;

namespace SUSS.DAL.Repositories
{
    public class LoginRepository : GenericRepository<UsersDetail>,ILoginRepository
    {
        public LoginRepository(IConfiguration configuration) : base(configuration)
        { }
       
        async Task<UsersDetail> ILoginRepository.ValidateUser(string Email, string Password)
        {
            //var query = @"EXEC " + DBConstant.CheckUserIsvalidByEmailID + " @Email,@Password";
            var query =  DBConstant.CheckIsUserValid ;
            UsersDetail users=new UsersDetail();
            using (var connection = CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("UserName",Email);
                parameters.Add("Password", Password);
                parameters.Add("Error_Code", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("Error_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                UsersDetail user = await connection.QuerySingleOrDefaultAsync<UsersDetail>(query, parameters, commandType:CommandType.StoredProcedure);
                user = (user == null) ? new UsersDetail() : user;
                user.Error_Message = parameters.Get<string>("Error_Message");
                user.Error_Code = parameters.Get<int?>("Error_Code");
                return user;
            }
        }
    }
}
