using Domain.Interface;
using Infrastructure.Records;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RinkuApp.Areas.Nominas.Models;

namespace RinkuApp.Areas.Nominas.Controllers
{
    [Route("Salario")]
    public class SalarioController : Controller
    {
        private ISalarioService _service;

        private readonly UserManager<IdentityUser> _userManager;
        public SalarioController(ISalarioService service, UserManager<IdentityUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            this.ViewBag.Data = _service.GetAll();
            this.ViewBag.Combo = _service.GetCombo();

            return View();
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar(SalariosModel model)
        {
            try
            {
                SalarioRecord empleadoRecord = new SalarioRecord()
                {
                    IdEmpleado = model.IdEmpleado,     
                    Mes = model.Mes,
                    UsuarioCreacion = _userManager.GetUserId(User),
                    CantidadEntregas = model.CantidadEntregas
                };
                _service.Guardar(empleadoRecord);

                return this.Json(new { StatusCode = 200 });
            }
            catch (Exception ex)
            {
                return this.Json(new { StatusCode = 500, Msg = ex.Message });
            }

        }
    }
}
