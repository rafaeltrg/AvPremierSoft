using System;

namespace AVPremierSoft.Domain.HoraProjeto.Model
{
    public class HoraProjetoModel
    {
        public Guid? Id { get; set; }
        public Guid IdProjeto { get; set; }
        public Guid IdColaborador { get; set; }
        public long QuantidadeHora { get; set; }
        public long QuantidadeMinuto { get; set; }
    }
}
