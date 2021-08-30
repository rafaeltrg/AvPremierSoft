using AVPremierSoft.Domain.Colaborador.Model;
using AVPremierSoft.Domain.Projeto.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.Equipe.Model
{
    public class EquipeModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public List<ColaboradorModel> Colaboradores { get; set; }
        public List<ProjetoModel> Projetos { get; set; }
    }
}
