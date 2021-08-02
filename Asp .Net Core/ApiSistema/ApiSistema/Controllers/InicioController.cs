using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSistema.Sistema;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API EJECUTANDOSE CORRECTAMENTE.");
        }
        [HttpGet]
        [Route("verificar")]
        public IActionResult GetConexion()
        {
            return Ok(new Respuesta() { Estado = true, Mensaje = Mensajes.CONEXION_SERVIDOR });
        }
    }
}
