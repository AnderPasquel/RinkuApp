using Dapper;
using Infrastructure.Identity.Data;
using Infrastructure.Interface;
using Infrastructure.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class SalarioRepository : ISalarioRepository
    {
        private IConnectionProvider _context;

        public SalarioRepository(IConnectionProvider context)
        {
            _context = context;
        }
        public IEnumerable<dynamic> GetAll()
        {
            using (var connection = _context.GetConnection())
            {
                var data = connection.Query<dynamic>("[dbo].[Salarios_GetAll]", commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public IEnumerable<dynamic> GetCombo()
        {
            using (var connection = _context.GetConnection())
            {
                var data = connection.Query<dynamic>("[dbo].[Salarios_GetCombo]", commandType: CommandType.StoredProcedure);
                return data;
            }
        }
        public IEnumerable<dynamic> GetDetails(long id, string mes)
        {
            using (var connection = _context.GetConnection())
            {
                var data = connection.Query<dynamic>("[dbo].[Salarios_GetDetails]",new { Id  = id , Mes = mes}, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public void Guardar(SalarioRecord record)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Execute("[dbo].[Salarios_Create]", record, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<dynamic> GetByMes(string mes)
        {
            using (var connection = _context.GetConnection())
            {
                var data = connection.Query<dynamic>("[dbo].[Salarios_GetByMes]", new { Mes = mes }, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
    }
}
