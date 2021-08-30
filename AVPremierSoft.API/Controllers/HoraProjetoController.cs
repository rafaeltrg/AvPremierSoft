using AVPremierSoft.Domain.HoraProjeto.Interface;
using AVPremierSoft.Domain.HoraProjeto.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace AVPremierSoft.API.Controllers
{
    public class HoraProjetoController : Controller
    {
        private readonly IHoraProjetoService _horaProjetoService;
        public HoraProjetoController(IHoraProjetoService horaProjetoService)
        {
            _horaProjetoService = horaProjetoService;
        }

        [HttpGet("v1/hora")]
        [Authorize(Roles = "gestor")]
        public IActionResult ListHoraProjeto([FromQueryAttribute] Guid? equipeId, [FromQueryAttribute] Guid? projetoId)
        {
            if (equipeId.HasValue)
                return Ok(_horaProjetoService.SelectByEquipeId((Guid)equipeId));

            if (projetoId.HasValue)
                return Ok(_horaProjetoService.SelectByProjetoId((Guid)projetoId));


            return Ok(_horaProjetoService.SelectAll());
        }

        [HttpPost("v1/hora")]
        [Authorize]
        public IActionResult InsertHoraProjeto([FromBody] HoraProjetoModel horaProjeto)
        {
            _horaProjetoService.InsertHoraProjeto(horaProjeto);
            return Ok("Hora inserida com sucesso!");
        }

        [HttpPut("v1/hora/{Id}")]
        [Authorize]
        public IActionResult UpdateHoraProjeto([FromBody] HoraProjetoModel horaProjeto, Guid Id)
        {
            horaProjeto.Id = Id;
            _horaProjetoService.UpdateHoraProjeto(horaProjeto);
            return Ok("Hora atualizado com sucesso!");
        }
        [HttpDelete("v1/hora/{Id}")]
        [Authorize]
        public IActionResult DeleteHoraProjeto(Guid Id)
        {
            _horaProjetoService.DeleteHoraProjeto(Id);
            return Ok("Hora deletada com sucesso!");
        }
    }
}
