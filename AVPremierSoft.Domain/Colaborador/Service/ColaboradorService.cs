using AVPremierSoft.Domain.Colaborador.Interface;
using AVPremierSoft.Domain.Colaborador.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVPremierSoft.Domain.Colaborador.Service
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public void InsertColaborador(ColaboradorModel colaborador)
        {
            _colaboradorRepository.Insert(colaborador);
        }
        public void UpdateColaborador(ColaboradorModel colaborador)
        {
            _colaboradorRepository.Update(colaborador);
        }
        public void DeleteColaborador(Guid Id)
        {
            _colaboradorRepository.Delete(Id);
        }
        public List<ColaboradorModel> SelectAll()
        {
            return _colaboradorRepository.SelectAll();
        }
    }
}
