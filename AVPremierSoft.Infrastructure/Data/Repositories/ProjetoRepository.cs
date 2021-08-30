using AVPremierSoft.Domain.Projeto.Interface;
using AVPremierSoft.Domain.Projeto.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AVPremierSoft.Infrastructure.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public ProjetoRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public void Delete(Guid id)
        {
            const string sql = @"delete from projeto where id = @Id";
            _databaseConnection._db.Execute(sql, new { Id = id }, commandType: CommandType.Text);
        }

        public void Insert(ProjetoModel projeto)
        {

            const string sql = @"insert into projeto (id, nome) values (@Id, @Nome)";
            _databaseConnection._db.Execute(sql, new { Id = projeto.Id, Nome = projeto.Nome }, commandType: CommandType.Text);

        }

        public ProjetoModel SelectById(Guid projetoId)
        {

            const string sql = @"select id, nome from projeto where id = @Id";
            return _databaseConnection._db.Query<ProjetoModel>(sql, new { Id = projetoId }, commandType: CommandType.Text).FirstOrDefault();

        }

        public List<ProjetoModel> SelectAll()
        {
            const string sql = @"select id, nome from projeto";
            return _databaseConnection._db.Query<ProjetoModel>(sql, commandType: CommandType.Text).ToList();
        }

        public void Update(ProjetoModel projeto)
        {
            const string sql = @"update projeto set nome = @Nome where id = @Id";
            _databaseConnection._db.Execute(sql, new { Id = projeto.Id, Nome = projeto.Nome }, commandType: CommandType.Text);
        }
    }
}

