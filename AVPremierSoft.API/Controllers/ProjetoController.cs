using AVPremierSoft.Domain.Projeto.Interface;
using AVPremierSoft.Domain.Projeto.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AVPremierSoft.API.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoService _projetoService;
        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet("v1/projeto")]
        [Authorize(Roles = "gestor")]
        public IActionResult ListProjeto()
        {
            return Ok(_projetoService.SelectAll());
        }

        [HttpPost("v1/projeto")]
        [Authorize(Roles = "gestor")]
        public IActionResult InsertProjeto([FromBody] ProjetoModel projeto)
        {
            _projetoService.InsertProjeto(projeto);
            return Ok("Projeto inserido com sucesso!");
        }

        [HttpPut("v1/projeto/{Id}")]
        [Authorize(Roles = "gestor")]
        public IActionResult UpdateProjeto([FromBody] ProjetoModel projeto, Guid Id)
        {
            projeto.Id = Id;
            _projetoService.UpdateProjeto(projeto);
            return Ok("Projeto atualizado com sucesso!");
        }
        [HttpDelete("v1/projeto/{Id}")]
        [Authorize(Roles = "gestor")]
        public IActionResult DeleteProjeto(Guid Id)
        {
            _projetoService.DeleteProjeto(Id);
            return Ok("Projeto atualizado com sucesso!");
        }
    }
}
