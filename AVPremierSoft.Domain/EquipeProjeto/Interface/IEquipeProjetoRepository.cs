using AVPremierSoft.Domain.EquipeProjeto.Model;
using System;


namespace AVPremierSoft.Domain.EquipeProjeto.Interface
{
    public interface IEquipeProjetoRepository
    {
        void Insert(EquipeProjetoModel equipe);
        EquipeProjetoModel SelectById(Guid equipeId);
        void DeleteByEquipeId(Guid equipeId);
        void DeleteByProjetoId(Guid projetoId);
    }
}
