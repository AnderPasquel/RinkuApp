using Infrastructure.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IEmpleadosRepository
    {
        IEnumerable<dynamic> GetAll();
        IEnumerable<dynamic> GetCombo();
        void Guardar(EmpleadoRecord record);
    }
}
