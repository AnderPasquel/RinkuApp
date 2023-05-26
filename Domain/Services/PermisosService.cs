using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PermisosService : IPermisosService
    {
        private IPermisosRepository _repository;
        public PermisosService(IPermisosRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<dynamic> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
