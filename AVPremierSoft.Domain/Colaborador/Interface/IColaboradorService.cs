using AVPremierSoft.Domain.Colaborador.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVPremierSoft.Domain.Colaborador.Interface
{
    public interface IColaboradorService
    {
        void InsertColaborador(ColaboradorModel colaborador);
        void UpdateColaborador(ColaboradorModel colaborador);
        void DeleteColaborador(Guid Id);
        List<ColaboradorModel> SelectAll();

    }
}
