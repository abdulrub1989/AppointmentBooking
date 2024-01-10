using Dapper;
using Microsoft.Extensions.Configuration;
using SUSS.DOM.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SUSS.DAL.Repositories
{
    public class ApproverRepository : BaseRepository, IApproverRepository
    {
        private readonly ICommonRepository _commonRepositry;
        public ApproverRepository(IConfiguration configuration, ICommonRepository commonRepositry) : base(configuration)
        {
            _commonRepositry=commonRepositry;
        }
        async Task<ApproverDOM> IApproverRepository.GetApproverDetailByBookingID(string BookingID)
        {
             ApproverDOM approverDOM = new ApproverDOM();
            string query = DBConstant.GetApproverDetailByBookingID;
            using (var connection = CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("BookingID", BookingID);
                parameters.Add("Error_Code", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("Error_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                var reader = await connection.QueryMultipleAsync(query, parameters, 
                    commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                if(reader != null)
                {
                    approverDOM.Users_Detail = (await reader.ReadFirstOrDefaultAsync<UsersDetail>().ConfigureAwait(false));
                    if (approverDOM.Users_Detail != null)
                    {
                        approverDOM.Users_Detail.Error_Code = 200;
                        approverDOM.Users_Detail.Error_Message = "Ok";
                        approverDOM.Form_D = (await reader.ReadFirstOrDefaultAsync<UserRegistration>().ConfigureAwait(false));
                        approverDOM.Form_M = (await reader.ReadFirstOrDefaultAsync<FormM>().ConfigureAwait(false));
                        approverDOM.Form_N = (await reader.ReadFirstOrDefaultAsync<FormN>().ConfigureAwait(false));
                        approverDOM.Form_O = (await reader.ReadFirstOrDefaultAsync<FormO>().ConfigureAwait(false));
                    }
                    else
                    {
                        Int32 Error_Code = parameters.Get<Int32>("Error_Code");
                        string Error_Message = parameters.Get<string>("Error_Message");
                        approverDOM.Users_Detail = new UsersDetail();
                        approverDOM.Users_Detail.Error_Code = Error_Code;
                        approverDOM.Users_Detail.Error_Message = Error_Message;
                    }
                }
            }
            return approverDOM;
        }

        async Task<int> IApproverRepository.UpdateApproveRequest(Approver approver)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ApproverID", approver.ApproverID);
            parameters.Add("UserID", approver.UserID);
            parameters.Add("StatusID", approver.Status);
            var rowsAffected = _commonRepositry.Execute(DBConstant.ApproverRequest, parameters,commandType: CommandType.StoredProcedure);
            if(rowsAffected>0)return rowsAffected;
            return 0;
        }
    }
}
