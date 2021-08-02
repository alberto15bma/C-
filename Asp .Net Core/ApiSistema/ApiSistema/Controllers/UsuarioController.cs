using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using ApiSistema.Logica;
using ApiSistema.Modelos.Configuracion.Tablas;
using ApiSistema.Sistema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiSistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]Usuarios usuario)
        {
            Respuesta respuesta = new Respuesta();
            var u = new ClsUsuario();
            Usuarios user = u.GetLogin(usuario);

            if (user != null)
            {
                if (!user.InicioSesion)
                {
                    respuesta.Mensaje = Mensajes.USUARIO_SIN_PERMISO_LOGIN;
                    respuesta.Estado = false;
                    respuesta.Data = null;
                    return Ok(respuesta);
                }
                if (user.Bloqueado)
                {
                    respuesta.Mensaje = Mensajes.USUARIO_BLOQUEADO;
                    respuesta.Estado = false;
                    respuesta.Data = null;
                    return Ok(respuesta);
                }
                dynamic data = new ExpandoObject();
                data.usuario = user;
                data.token = Token.GenerarToken(user.Usuario, user.Id);

                respuesta.Mensaje = Mensajes.LOGIN_CORRECTO;
                respuesta.Estado = true;
                respuesta.Data = data;
                return Ok(respuesta);
            }
            else
            {
                respuesta.Mensaje = Mensajes.ERROR_LOGIN;
                respuesta.Estado = false;
                return Ok(respuesta);
            }
        }
    }
}