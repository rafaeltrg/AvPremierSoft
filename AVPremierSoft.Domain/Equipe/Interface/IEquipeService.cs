using AVPremierSoft.Domain.Equipe.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVPremierSoft.Domain.Equipe.Interface
{
    public interface IEquipeService
    {
        EquipeModel ReturnEquipeById(Guid id);
        void InsertEquipe(EquipeModel equipe);
        void UpdateEquipe(EquipeModel equipe);
        void DeleteEquipe(Guid id);
        List<EquipeModel> SelectAll();
    }
}
