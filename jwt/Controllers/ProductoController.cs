using jwt.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //esta ruta la protejemos con el jwt
        [HttpGet]
        [Authorize]

        public ActionResult Get()
        {
            var listaProductos = ProductosConstants.Productos;
            return Ok(listaProductos);
        }
    }
}
