using AVPremierSoft.Domain.Equipe.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.Colaborador.Model
{
    public class ColaboradorModel
    {
        public Guid? Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Role { get; set; }
    }
}
