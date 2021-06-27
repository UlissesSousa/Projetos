using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceNamespace.Application.Interfaces;
using ServiceNamespace.Application.Models;

namespace ServiceNamespace.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ApiBaseController
    {
        private readonly IUsuarioApplication _usuarioApplication;
        public UsuarioController( IUsuarioApplication usuarioApplication) 
        {
            _usuarioApplication = usuarioApplication;
        }

        [HttpPost]
        [Route("validarSenha")]
        [ProducesResponseType(typeof(UsuarioPostModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Validar(UsuarioPostModel usuarioModel)
        {
            var result = _usuarioApplication.Salvar(usuarioModel);

            if (result.Success)
                return Ok(true);

            return BadRequest(result.Notifications);
        }

    }
}
