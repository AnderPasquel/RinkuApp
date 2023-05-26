using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Data
{
    public interface IConnectionProvider
    {
        SqlConnection GetConnection();
    }
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly IConfiguration _configuration;
        public ConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection GetConnection()
        {
            var conn = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(conn);
            return connection;
        }

    }
}
