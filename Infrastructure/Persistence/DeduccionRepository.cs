using Dapper;
using Infrastructure.Identity.Data;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DeduccionRepository : IDeduccionRepository
    {
        private IConnectionProvider _context;

        public DeduccionRepository(IConnectionProvider context)
        {
            _context = context;
        }
        public IEnumerable<dynamic> GetAll()
        {
            using (var connection = _context.GetConnection())
            {
                var products = connection.Query<dynamic>("SELECT * FROM Deducciones");
                return products;
            }
        }
    }
}
