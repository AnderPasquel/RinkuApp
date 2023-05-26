using Domain.Interface;
using Infrastructure.Interface;
using Infrastructure.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EmpleadosService : IEmpleadosService
    {
        private IEmpleadosRepository _repository;
        public EmpleadosService(IEmpleadosRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<dynamic> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<dynamic> GetCombo()
        {
            return _repository.GetCombo();
        }

        public void Guardar(EmpleadoRecord record)
        {
            _repository.Guardar(record);
        }
    }
}
