using Microsoft.Extensions.Configuration;
using SUSS.DOM.Entities;
using System.Data;

namespace SUSS.DAL.Repositories
{
    public class Booking : IBooking
    {
        private readonly ICommonRepository _commonRepositry;
        private readonly ICounsellingType _counsellingType;
        public Booking(IConfiguration configuration, ICounsellingType counsellingType, ICommonRepository commonRepositry)
        {
            _counsellingType = counsellingType;
            _commonRepositry = commonRepositry;
        }
        async Task<int> IBooking.CreateBooking(FormM formM_data)
        {
            formM_data.CounsellingID = _counsellingType.GetCounsellingType();
            FormM result = await Task.FromResult(_commonRepositry.Insert<FormM>(DBConstant.CreateFormM
               , formM_data,
               commandType: CommandType.StoredProcedure));
            return result.BookingID;
        }
    }
}
