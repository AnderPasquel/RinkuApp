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
    public class SalarioService : ISalarioService
    {
        private ISalarioRepository _repository;
        public SalarioService(ISalarioRepository repository)
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

        public void Guardar(SalarioRecord record)
        {
            _repository.Guardar(record);
        }

        public IEnumerable<dynamic> GetDetails(long id, string mes)
        {
            return _repository.GetDetails(id, mes);
        }

        public IEnumerable<dynamic> GetByMes(string mes)
        {
            return _repository.GetByMes(mes);
        }
    }
}
