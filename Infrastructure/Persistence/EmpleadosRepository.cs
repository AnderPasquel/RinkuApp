using Dapper;
using Infrastructure.Identity.Data;
using Infrastructure.Interface;
using Infrastructure.Records;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Persistence
{
    public class EmpleadosRepository : IEmpleadosRepository
    {
        private IConnectionProvider _context;

        public EmpleadosRepository(IConnectionProvider context)
        {
            _context = context;
        }
        public IEnumerable<dynamic> GetAll()
        {
            using (var connection = _context.GetConnection())
            {
                var data = connection.Query<dynamic>("[dbo].[Empleados_GetAll]", commandType: CommandType.StoredProcedure);
                return data;
            }
        }
        public IEnumerable<dynamic> GetCombo()
        {
            using (var connection = _context.GetConnection())
            {
                var data = connection.Query<dynamic>("[dbo].[Empleados_GetCombo]", commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        public void Guardar(EmpleadoRecord record)
        {
            using (var connection = _context.GetConnection())
            {
                connection.Execute("[dbo].[Empleados_Create]", record, commandType: CommandType.StoredProcedure);                
            }
        }
    }
}
