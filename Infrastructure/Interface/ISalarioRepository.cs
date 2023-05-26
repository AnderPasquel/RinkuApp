using Infrastructure.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface ISalarioRepository
    {
        IEnumerable<dynamic> GetAll();
        IEnumerable<dynamic> GetCombo();
        void Guardar(SalarioRecord record);
        IEnumerable<dynamic> GetDetails(long id, string mes);
        IEnumerable<dynamic> GetByMes(string mes);
    }
}
