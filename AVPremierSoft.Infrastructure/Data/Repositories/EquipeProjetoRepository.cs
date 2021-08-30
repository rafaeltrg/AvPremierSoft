using AVPremierSoft.Domain.EquipeProjeto.Interface;
using AVPremierSoft.Domain.EquipeProjeto.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;

namespace AVPremierSoft.Infrastructure.Data.Repositories
{
    public class EquipeProjetoRepository : IEquipeProjetoRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public EquipeProjetoRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void DeleteByEquipeId(Guid equipeId)
        {
            const string sql = @"delete from equipe_projeto where id_equipe = @Id";
            _databaseConnection._db.Execute(sql, new { Id = equipeId }, commandType: CommandType.Text);
        }
        public void DeleteByProjetoId(Guid projetoId)
        {
            const string sql = @"delete from equipe_projeto where id_projeto = @Id";
            _databaseConnection._db.Execute(sql, new { Id = projetoId }, commandType: CommandType.Text);
        }

        public void Insert(EquipeProjetoModel equipeProjeto)
        {
            const string sql = @"insert into equipe_projeto (id_equipe, id_projeto) values (@IdEquipe, @IdProjeto)";
            _databaseConnection._db.Execute(sql, new { IdEquipe = equipeProjeto.IdEquipe, IdProjeto = equipeProjeto.IdProjeto }, commandType: CommandType.Text);
        }

        public EquipeProjetoModel SelectByEquipeId(Guid equipeId)
        {
            const string sql = @"select id_equipe, id_projeto from projeto where id_equipe = @IdEquipe";
            return _databaseConnection._db.Query<EquipeProjetoModel>(sql, new { IdEquipe = equipeId }, commandType: CommandType.Text).FirstOrDefault();
        }

        public EquipeProjetoModel SelectById(Guid projetoId)
        {
            const string sql = @"select id_equipe, id_projeto from projeto where id_equipe = @IdProjeto";
            return _databaseConnection._db.Query<EquipeProjetoModel>(sql, new { IdProjeto = projetoId }, commandType: CommandType.Text).FirstOrDefault();
        }
    }
}
