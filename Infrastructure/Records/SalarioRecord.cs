using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Records
{
    public record SalarioRecord
    {
        public int IdEmpleado { get; set; }
        public int CantidadEntregas { get; set; }
        public string Mes { get; set; }
        public string UsuarioCreacion { get; set; }
    }
}
