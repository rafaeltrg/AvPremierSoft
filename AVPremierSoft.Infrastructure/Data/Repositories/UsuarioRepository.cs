using AVPremierSoft.Domain.Usuario.Interface;
using AVPremierSoft.Domain.Usuario.Model;
using Dapper;
using System;
using System.Data;
using System.Linq;

namespace AVPremierSoft.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public UsuarioRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void Delete(Guid usuarioId)
        {

            const string sql = @"delete from usuario where id = @Id";
            _databaseConnection._db.Execute(sql, new { Id = usuarioId }, commandType: CommandType.Text);

        }

        public void Insert(UsuarioModel usuario)
        {

            const string sql = @"insert into usuario (id, email, senha) values (@Id, @Email, @Senha)";
            _databaseConnection._db.Execute(sql, new { Id = usuario.Id, IdEquipe = usuario.Id, Nome = usuario.Email, Telefone = usuario.Senha}, commandType: CommandType.Text);

        }

        public void Update(UsuarioModel usuario)
        {

            const string sql = @"update colaborador set email = @Email, senha = @Senha where id = @Id";
            _databaseConnection._db.Execute(sql, new { Id = usuario.Id, Email = usuario.Email, Senha = usuario.Senha}, commandType: CommandType.Text);

        }

        public UsuarioModel SelectByEmailSenha(string email, string senha)
        {

            const string sql = @"select id, email  from usuario where email = @Email and senha = @Senha";
            return _databaseConnection._db.Query<UsuarioModel>(sql, new { Email = email, Senha = senha }, commandType: CommandType.Text).FirstOrDefault();

        }
    }
}
