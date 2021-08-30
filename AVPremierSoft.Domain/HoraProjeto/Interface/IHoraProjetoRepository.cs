using AVPremierSoft.Domain.HoraProjeto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVPremierSoft.Domain.HoraProjeto.Interface
{
    public interface IHoraProjetoRepository
    {
        void Insert(HoraProjetoModel horaProjeto);
        void Update(HoraProjetoModel horaProjeto);
        void Delete(Guid horaProjetoId);
        HoraProjetoModel SelectById(Guid horaProjetoId);
        List<HoraProjetoModel> SelectAll();
        List<HoraProjetoModel> SelectByProjetoId(Guid idEquipe);
        List<HoraProjetoModel> SelectByEquipeId(Guid idEquipe);
    }
}
