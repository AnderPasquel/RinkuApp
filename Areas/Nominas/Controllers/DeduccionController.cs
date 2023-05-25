using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RinkuApp.Areas.Nominas.Controllers
{
    [Route("Deduccion")]
    public class DeduccionController : Controller
    {
        private IDeduccionService _service;

        public DeduccionController(IDeduccionService service)
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
