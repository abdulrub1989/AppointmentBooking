using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SUSS.DAL.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IConfiguration _configuration;

        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        }
    }
}
