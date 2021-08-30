using AVPremierSoft.Domain.EquipeProjeto.Model;
using System;

namespace AVPremierSoft.Domain.EquipeProjeto.Interface
{
    public interface IEquipeProjetoService
    {
        void InsertEquipeProjeto(EquipeProjetoModel equipe);
        void DeleteByProjetoId(Guid projetoId);
        void DeleteByEquipeId(Guid equipeId);

    }
}
