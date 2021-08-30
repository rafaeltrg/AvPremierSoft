using AVPremierSoft.Domain.Equipe.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.Equipe.Interface
{
    public interface IEquipeRepository
    {
        void Insert(EquipeModel equipe);
        EquipeModel SelectById(Guid equipeId);
        void Update(EquipeModel equipe);
        void Delete(Guid id);
        List<EquipeModel> SelectAll();
    }
}
