using AVPremierSoft.Domain.EquipeProjeto.Interface;
using AVPremierSoft.Domain.EquipeProjeto.Model;
using System;

namespace AVPremierSoft.Domain.EquipeProjeto.Service
{
    public class EquipeProjetoService : IEquipeProjetoService
    {
        private readonly IEquipeProjetoRepository _equipeProjetoRepository;
        public EquipeProjetoService(IEquipeProjetoRepository equipeProjetoRepository)
        {
            _equipeProjetoRepository = equipeProjetoRepository;
        }

        public void DeleteByEquipeId(Guid equipeId)
        {
            _equipeProjetoRepository.DeleteByEquipeId(equipeId);
        }

        public void DeleteByProjetoId(Guid projetoId)
        {
            _equipeProjetoRepository.DeleteByProjetoId(projetoId);
        }

        public void InsertEquipeProjeto(EquipeProjetoModel colaborador)
        {
            _equipeProjetoRepository.Insert(colaborador);
        }
    }
}