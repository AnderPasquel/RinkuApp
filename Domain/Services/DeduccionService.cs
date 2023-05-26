using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DeduccionService : IDeduccionService
    {
        private IDeduccionRepository _repository;
        public DeduccionService(IDeduccionRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<dynamic> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
