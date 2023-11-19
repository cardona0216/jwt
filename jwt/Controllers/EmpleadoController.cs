using jwt.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles =("administrador"))]
        public IActionResult Get()
        {
            var listaEmpleados = EmpleadosConstants.Empleados;
            return Ok(listaEmpleados);
        }
    }
}
