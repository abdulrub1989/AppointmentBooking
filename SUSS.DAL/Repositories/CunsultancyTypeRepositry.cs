using Dapper;
using Microsoft.Extensions.Configuration;
using SUSS.DOM.Entities;
using System.Data;

namespace SUSS.DAL.Repositories
{
    public class CunsultancyTypeRepositry : BaseRepository,ICunsultancyType
    {
        private readonly ICommonRepository _commonRepository;
        public CunsultancyTypeRepositry(IConfiguration configuration,ICommonRepository commonRepository):base(configuration)
        {
          _commonRepository = commonRepository;
        }

        async Task<BaseEntity> ICunsultancyType.CheckCunsultancyExist(string EmailID,int CunsultancyID)
        {
            var query = DBConstant.CheckUserIsvalidByEmailID;
            using (var connection = CreateConnection())
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("EmailID", EmailID);
                dynamicParameters.Add("CounsellingID", CunsultancyID);
                dynamicParameters.Add("Error_Code", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("Error_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                BaseEntity result = await connection.QuerySingleOrDefaultAsync<BaseEntity>(query, dynamicParameters, commandType: CommandType.StoredProcedure);
                result = (result == null) ? new UsersDetail() : result;
                result.Error_Message = dynamicParameters.Get<string>("Error_Message");
                result.Error_Code = dynamicParameters.Get<int?>("Error_Code");
                return result;
            }
            
        } 

        async Task<IList<CunsultancyType>> ICunsultancyType.GetCunsultancyType()
        {
            var parameters = new DynamicParameters();
           return _commonRepository.GetAll<CunsultancyType>(DBConstant.GetCounsellingMaster, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
