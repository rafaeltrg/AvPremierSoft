using AVPremierSoft.Domain.Colaborador.Interface;
using AVPremierSoft.Domain.Equipe.Interface;
using AVPremierSoft.Domain.Equipe.Model;
using AVPremierSoft.Domain.EquipeProjeto.Interface;
using AVPremierSoft.Domain.EquipeProjeto.Model;
using AVPremierSoft.Domain.Projeto.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.Equipe.Service
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IEquipeProjetoRepository _equipeProjetoRepository;
        public EquipeService(IEquipeRepository equipeRepository, IColaboradorRepository colaboradorRepository, IEquipeProjetoRepository equipeProjetoRepository)
        {
            _equipeRepository = equipeRepository;
            _colaboradorRepository = colaboradorRepository;
            _equipeProjetoRepository = equipeProjetoRepository;
        }

        public void DeleteEquipe(Guid id)
        {
            _equipeProjetoRepository.DeleteByEquipeId(id);
            _equipeRepository.Delete(id);
        }

        public void InsertEquipe(EquipeModel equipe)
        {
            _equipeRepository.Insert(equipe);
            InsertProjetoEquipe(equipe.Projetos, (Guid)equipe.Id);
        }

        public EquipeModel ReturnEquipeById(Guid id)
        {
            var equipe = _equipeRepository.SelectById(id);
            equipe.Colaboradores = _colaboradorRepository.SelectByEquipeId(id);           
            return equipe;
        }

        public List<EquipeModel> SelectAll()
        {
            return _equipeRepository.SelectAll();
        }

        public void UpdateEquipe(EquipeModel equipe)
        {
            _equipeProjetoRepository.DeleteByEquipeId((Guid)equipe.Id);

            InsertProjetoEquipe(equipe.Projetos, (Guid)equipe.Id);

            _equipeRepository.Update(equipe);
        }
        private void InsertProjetoEquipe(List<ProjetoModel> projetos, Guid equipeId)
        {
            foreach (var projeto in projetos)
            {
                var equipeProjeto = new EquipeProjetoModel { IdProjeto = (Guid)projeto.Id, IdEquipe = equipeId };
                _equipeProjetoRepository.Insert(equipeProjeto);
            }
        }
    }
}
