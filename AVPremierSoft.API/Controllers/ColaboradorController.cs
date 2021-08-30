using AVPremierSoft.Domain.Colaborador.Interface;
using AVPremierSoft.Domain.Colaborador.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AVPremierSoft.API.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorService _colaboradorService;
        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet("v1/colaborador")]
        [Authorize(Roles = "gestor")]
        public IActionResult ListColaborador()
        {
            return Ok(_colaboradorService.SelectAll());
        }

        [HttpPost("v1/colaborador")]
        [Authorize(Roles = "gestor")]
        public IActionResult InsertColaborador([FromBody]ColaboradorModel colaborador) 
        {
            _colaboradorService.InsertColaborador(colaborador);
            return Ok("Colaborador inserido com sucesso!");
        }

        [HttpPut("v1/colaborador/{Id}")]
        [Authorize(Roles = "gestor")]
        public IActionResult UpdateColaborador([FromBody] ColaboradorModel colaborador, Guid Id)
        {
            colaborador.Id = Id;
            _colaboradorService.UpdateColaborador(colaborador);
            return Ok("Colaborador atualizado com sucesso!");
        }
        [HttpDelete("v1/colaborador/{Id}")]
        [Authorize(Roles = "gestor")]
        public IActionResult DeleteColaborador( Guid Id)
        {
            _colaboradorService.DeleteColaborador(Id);
            return Ok("Colaborador atualizado com sucesso!");
        }
    }
}
