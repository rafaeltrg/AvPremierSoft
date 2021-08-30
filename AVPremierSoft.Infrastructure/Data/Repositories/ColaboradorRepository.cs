using Dapper;
using AVPremierSoft.Domain.Colaborador.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Linq;
using AVPremierSoft.Domain.Colaborador.Interface;
using System.Collections.Generic;

namespace AVPremierSoft.Infrastructure.Data.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public ColaboradorRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        } 

        public void Insert(ColaboradorModel colaborador)
        {            
            const string sql = @"insert into colaborador (id, id_equipe, nome, telefone, role) values (@Id, @IdEquipe, @Nome, @Telefone, @Role)";
            _databaseConnection._db.Execute(sql, new { Id = colaborador.Id, IdEquipe = colaborador.IdEquipe, Nome = colaborador.Nome, Telefone = colaborador.Telefone, Role = colaborador.Role }, commandType: CommandType.Text);
        }

        public void Update(ColaboradorModel colaborador)
        {
            const string sql = @"update colaborador set id_equipe = @IdEquipe, nome = @Nome, telefone = @Telefone, role = @Role where id = @Id";
            _databaseConnection._db.Execute(sql, new { Id = colaborador.Id, IdEquipe = colaborador.IdEquipe, Nome = colaborador.Nome, Telefone = colaborador.Telefone, Role = colaborador.Role }, commandType: CommandType.Text);
        }

        public void Delete(Guid colaboradorId)
        {
            const string sql = @"delete from colaborador where id = @Id";
            _databaseConnection._db.Execute(sql, new { Id = colaboradorId }, commandType: CommandType.Text);
        }

        public ColaboradorModel SelectById(Guid idColaborador)
        {
            const string sql = @"select id, nome, email, telefone, role from colaborador where id = @Id";
            return _databaseConnection._db.Query<ColaboradorModel>(sql, new { Id = idColaborador }, commandType: CommandType.Text).FirstOrDefault();
        }

        public List<ColaboradorModel> SelectByEquipeId(Guid idEquipe)
        {
            const string sql = @"select id, nome, email, telefone, role from colaborador where id_equipe = @EquipeId";
            return _databaseConnection._db.Query<ColaboradorModel>(sql, new { Id = idEquipe }, commandType: CommandType.Text).ToList();
        }
        public List<ColaboradorModel> SelectAll()
        {
            const string sql = @"select id, nome, email, telefone, role from colaborador";
            return _databaseConnection._db.Query<ColaboradorModel>(sql, commandType: CommandType.Text).ToList();
        }

        public ColaboradorModel SelectByEmail(string email)
        {
            const string sql = @"select id, nome, email, telefone, role from colaborador where email = @Email";
            return _databaseConnection._db.Query<ColaboradorModel>(sql, new { Email = email }, commandType: CommandType.Text).FirstOrDefault();
        }
    }
}
