using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;
using AVPremierSoft.Domain.Equipe.Interface;
using AVPremierSoft.Domain.Equipe.Model;
using System.Collections.Generic;

namespace AVPremierSoft.Infrastructure.Data.Repositories
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public EquipeRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void Delete(Guid id)
        {
            const string sql = @"delete from equipe where id = @Id";
            _databaseConnection._db.Execute(sql, new { Id = id }, commandType: CommandType.Text);
        }

        public void Insert(EquipeModel equipe)
        {
            const string sql = @"insert into equipe (id, nome) values (@Id, @Nome)";
            _databaseConnection._db.Execute(sql, new { Id = equipe.Id, Nome = equipe.Nome }, commandType: CommandType.Text);
        }

        public List<EquipeModel> SelectAll()
        {
            const string sql = @"select id, nome from equipe";
            return _databaseConnection._db.Query<EquipeModel>(sql, commandType: CommandType.Text).ToList();
        }

        public EquipeModel SelectById(Guid equipeId)
        {
            const string sql = @"select id, nome from equipe where id = @Id";
            return _databaseConnection._db.Query<EquipeModel>(sql, new { Id = equipeId }, commandType: CommandType.Text).FirstOrDefault();
        }

        public void Update(EquipeModel equipe)
        {
            const string sql = @"update equipe set nome = @Nome where id = @Id";
            _databaseConnection._db.Execute(sql, new { Id = equipe.Id, Nome = equipe.Nome }, commandType: CommandType.Text);
        }
    }
}
