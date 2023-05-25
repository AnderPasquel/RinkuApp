using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RinkuApp.Areas.Nominas.Controllers
{
    [Route("Departameto")]
    public class DepartametoController : Controller
    {
        private IDepartametoService _service;

        public DepartametoController(IDepartametoService service)
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
