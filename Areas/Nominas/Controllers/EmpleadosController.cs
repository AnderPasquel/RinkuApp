using Domain.Interface;
using Infrastructure.Records;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RinkuApp.Areas.Nominas.Models;

namespace RinkuApp.Areas.Nominas.Controllers
{
    [Route("Empleados")]
    public class EmpleadosController : Controller
    {
        private IEmpleadosService _service;

        private readonly UserManager<IdentityUser> _userManager;

        public EmpleadosController(IEmpleadosService service, UserManager<IdentityUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            this.ViewBag.Data =  _service.GetAll();
            this.ViewBag.Combo = _service.GetCombo();

            return View();
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar(EmpleadoModel model)
        {
            try 
            {
                EmpleadoRecord empleadoRecord = new EmpleadoRecord()
                {
                    IdRol = model.IdRol,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    CorreoElectronico = model.CorreoElectronico,
                    Telefono = "",
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    UsuarioCreacion = _userManager.GetUserId(User),
                    UsuarioModificacion = _userManager.GetUserId(User),
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
