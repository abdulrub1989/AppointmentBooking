using Microsoft.Extensions.Configuration;
using SUSS.DOM.Entities;
using System.Data;

namespace SUSS.DAL.Repositories
{
    public class FormNRepositry : IFormNRepositry
    {
        private readonly ICommonRepository _commonRepositry;
        private readonly ICounsellingType _counsellingType;
        public FormNRepositry(IConfiguration configuration, ICounsellingType counsellingType, ICommonRepository commonRepositry)
        {
            _counsellingType = counsellingType;
            _commonRepositry = commonRepositry;
        }
        async Task<int> IFormNRepositry.CreateFormN(FormN formN_data)
        {
            formN_data.CounsellingID = _counsellingType.GetCounsellingType();
            FormN result = await Task.FromResult(_commonRepositry.Insert<FormN>(DBConstant.CreateFormN
               , formN_data,
               commandType: CommandType.StoredProcedure));
            return result.ID;
        }
    }
}
