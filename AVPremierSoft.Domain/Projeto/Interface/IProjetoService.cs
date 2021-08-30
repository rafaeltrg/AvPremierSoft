using AVPremierSoft.Domain.Projeto.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.Projeto.Interface
{
    public interface IProjetoService
    {
        ProjetoModel ReturnProjetoById(Guid id);
        void InsertProjeto(ProjetoModel projeto);
        void UpdateProjeto(ProjetoModel projeto);
        void DeleteProjeto(Guid id);
        List<ProjetoModel> SelectAll();
    }
}
