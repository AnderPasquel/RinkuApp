using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RinkuApp.Areas.Nominas.Controllers
{
    [Route("Permisos")]
    public class PermisosController : Controller
    {
        private IPermisosService _service;

        public PermisosController(IPermisosService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {

            this.ViewBag.Data = _service.GetAll();

            var list = _service.GetAll();
            return View();
        }
    }
}
