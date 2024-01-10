using Microsoft.Extensions.Configuration;
using SUSS.DOM.Entities;
using System.Data;

namespace SUSS.DAL.Repositories
{
    public class FormORepositry : IFormORepositry
    {
        private readonly ICommonRepository _commonRepositry;
        private readonly ICounsellingType _counsellingType;
        public FormORepositry(IConfiguration configuration, ICounsellingType counsellingType, ICommonRepository commonRepositry)
        {
            _counsellingType = counsellingType;
            _commonRepositry = commonRepositry;
        }
        async Task<int> IFormORepositry.CreateFormO(FormO formO_data)
        {
            formO_data.CounsellingID = _counsellingType.GetCounsellingType();
            FormO result = await Task.FromResult(_commonRepositry.Insert<FormO>(DBConstant.CreateFormO
               , formO_data,
               commandType: CommandType.StoredProcedure));
            return result.BookingID;
        }
    }
}
