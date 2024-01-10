using Dapper;
using SUSS.DOM.Entities;
using System.Data;

namespace SUSS.DAL.Repositories
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        T Insert<T>(string sp, T parms, CommandType commandType = CommandType.StoredProcedure);
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, T parms, CommandType commandType = CommandType.StoredProcedure);
        int Delete<T>(string sp, T parms, CommandType commandType = CommandType.StoredProcedure);
    }
}
