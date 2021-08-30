using AVPremierSoft.Domain.Usuario.Interface;
using AVPremierSoft.Domain.Usuario.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace AVPremierSoft.API.Controllers
{
    public class AutenticadorController : Controller
    {
        private readonly IUsuarioService _usuarioService; 
        public AutenticadorController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpPost("v1/autenticar")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UsuarioModel usuario)
        {
            var token = _usuarioService.AuthenticateUsuario(usuario.Email, usuario.Senha);
            if (String.IsNullOrEmpty(token))          
                return Unauthorized();
            
            return Ok(token);
        }
    }
}
