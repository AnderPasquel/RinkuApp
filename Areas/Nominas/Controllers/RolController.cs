using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RinkuApp.Areas.Nominas.Controllers
{
    [Route("Rol")]
    public class RolController : Controller
    {
        private IRolService _service;

        public RolController(IRolService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {

            this.ViewBag.Data = _service.GetAll();

            return View();
        }
    }
}
