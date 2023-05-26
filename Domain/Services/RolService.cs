using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RolService : IRolService
    {

        private IRolRepository _repository;
        public RolService(IRolRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<dynamic> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
