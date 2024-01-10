using SUSS.DOM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSS.DAL.Repositories
{
    public interface ICunsultancyType
    {
        Task<IList<CunsultancyType>> GetCunsultancyType();
        Task<BaseEntity> CheckCunsultancyExist(string EmailID, int CunsultancyID);
    }
}
