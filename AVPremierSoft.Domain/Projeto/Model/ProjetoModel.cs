using AVPremierSoft.Domain.Equipe.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.Projeto.Model
{
    public class ProjetoModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public List<EquipeModel> Equipes { get; set; }
    }
}
