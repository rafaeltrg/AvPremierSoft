using AVPremierSoft.Domain.Colaborador.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.Colaborador.Interface
{
    public interface IColaboradorRepository
    {
        void Insert(ColaboradorModel colaborador);
        void Update(ColaboradorModel colaborador);
        void Delete(Guid colaboradorId);
        ColaboradorModel SelectById(Guid colaboradorId);
        ColaboradorModel SelectByEmail(string email);
        List<ColaboradorModel> SelectByEquipeId(Guid idEquipe);
        List<ColaboradorModel> SelectAll();
    }
}
