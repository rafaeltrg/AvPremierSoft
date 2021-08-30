using AVPremierSoft.Domain.HoraProjeto.Interface;
using AVPremierSoft.Domain.HoraProjeto.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.HoraProjeto.Service
{
    public class HoraProjetoService : IHoraProjetoService
    {
        private readonly IHoraProjetoRepository _horaProjetoRepository;
        public HoraProjetoService(IHoraProjetoRepository horaProjetoRepository)
        {
            _horaProjetoRepository = horaProjetoRepository;
        }

        public void InsertHoraProjeto(HoraProjetoModel horaProjeto)
        {
            _horaProjetoRepository.Insert(horaProjeto);
        }
        public void UpdateHoraProjeto(HoraProjetoModel horaProjeto)
        {
            _horaProjetoRepository.Update(horaProjeto);
        }
        public void DeleteHoraProjeto(Guid Id)
        {
            _horaProjetoRepository.Delete(Id);
        }
        public List<HoraProjetoModel> SelectAll()
        {
            return _horaProjetoRepository.SelectAll();
        }

        public List<HoraProjetoModel> SelectByProjetoId(Guid idEquipe)
        {
            return _horaProjetoRepository.SelectByEquipeId(idEquipe);
        }

        public List<HoraProjetoModel> SelectByEquipeId(Guid idProjeto)
        {
            return _horaProjetoRepository.SelectByProjetoId(idProjeto);
        }
    }
}
