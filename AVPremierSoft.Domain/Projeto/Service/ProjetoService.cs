using AVPremierSoft.Domain.Equipe.Model;
using AVPremierSoft.Domain.EquipeProjeto.Interface;
using AVPremierSoft.Domain.EquipeProjeto.Model;
using AVPremierSoft.Domain.Projeto.Interface;
using AVPremierSoft.Domain.Projeto.Model;
using System;
using System.Collections.Generic;

namespace AVPremierSoft.Domain.Projeto.Service
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IEquipeProjetoRepository _equipeProjetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository, IEquipeProjetoRepository equipeProjetoRepository)
        {
            _projetoRepository = projetoRepository;
            _equipeProjetoRepository = equipeProjetoRepository;
        }

        public void DeleteProjeto(Guid id)
        {
            _equipeProjetoRepository.DeleteByProjetoId(id);
            _projetoRepository.Delete(id);
        }

        public void InsertProjeto(ProjetoModel projeto)
        {
            _projetoRepository.Insert(projeto);
            InsertProjetoEquipe(projeto.Equipes, (Guid)projeto.Id);
        }

        public ProjetoModel ReturnProjetoById(Guid id)
        {
            return _projetoRepository.SelectById(id); ;
        }

        public List<ProjetoModel> SelectAll()
        {
            return _projetoRepository.SelectAll();
        }

        public void UpdateProjeto(ProjetoModel projeto)
        {
            _equipeProjetoRepository.DeleteByProjetoId((Guid)projeto.Id);

            InsertProjetoEquipe(projeto.Equipes, (Guid)projeto.Id);

            _projetoRepository.Update(projeto);
        }
        private void InsertProjetoEquipe(List<EquipeModel> equipes, Guid projetoId)
        {
            foreach (var equipe in equipes)
            {
                var equipeProjeto = new EquipeProjetoModel { IdProjeto = projetoId, IdEquipe = (Guid)equipe.Id };
                _equipeProjetoRepository.Insert(equipeProjeto);
            }
        }
    }
}
