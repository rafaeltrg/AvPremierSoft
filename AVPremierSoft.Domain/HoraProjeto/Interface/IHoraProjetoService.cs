using AVPremierSoft.Domain.HoraProjeto.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.HoraProjeto.Interface
{
    public interface IHoraProjetoService
    {
        void InsertHoraProjeto(HoraProjetoModel horaProjeto);
        void UpdateHoraProjeto(HoraProjetoModel horaProjeto);
        void DeleteHoraProjeto(Guid Id);
        List<HoraProjetoModel> SelectAll();
        List<HoraProjetoModel> SelectByProjetoId(Guid idProjeto);
        List<HoraProjetoModel> SelectByEquipeId(Guid idEquipe);
    }
}
