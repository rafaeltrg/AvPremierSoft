using AVPremierSoft.Domain.Projeto.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.Projeto.Interface
{
    public interface IProjetoRepository
    {
        void Insert(ProjetoModel projeto);
        ProjetoModel SelectById(Guid projetoId);
        void Update(ProjetoModel projeto);
        void Delete(Guid id);
        List<ProjetoModel> SelectAll();
    }
}
