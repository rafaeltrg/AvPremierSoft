using AVPremierSoft.Domain.Equipe.Interface;
using AVPremierSoft.Domain.Equipe.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AVPremierSoft.API.Controllers
{
    public class EquipeController : Controller
    {
        private readonly IEquipeService _equipeService;
        public EquipeController(IEquipeService equipeService)
        {
            _equipeService = equipeService;
        }

        [HttpGet("v1/equipe")]
        [Authorize(Roles = "gestor")]
        public IActionResult ListEquipe()
        {
            return Ok(_equipeService.SelectAll());
        }

        [HttpPost("v1/equipe")]
        [Authorize(Roles = "gestor")]
        public IActionResult InsertEquipe([FromBody] EquipeModel equipe)
        {
            _equipeService.InsertEquipe(equipe);
            return Ok("Equipe inserido com sucesso!");
        }

        [HttpPut("v1/equipe/{Id}")]
        [Authorize(Roles = "gestor")]
        public IActionResult UpdateEquipe([FromBody] EquipeModel equipe, Guid Id)
        {
            equipe.Id = Id;
            _equipeService.UpdateEquipe(equipe);
            return Ok("Equipe atualizado com sucesso!");
        }
        [HttpDelete("v1/equipe/{Id}")]
        [Authorize(Roles = "gestor")]
        public IActionResult DeleteEquipe(Guid Id)
        {
            _equipeService.DeleteEquipe(Id);
            return Ok("Equipe atualizado com sucesso!");
        }
    }
}
