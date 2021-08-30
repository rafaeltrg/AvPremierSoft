using AVPremierSoft.Domain.HoraProjeto.Interface;
using AVPremierSoft.Domain.HoraProjeto.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AVPremierSoft.Infrastructure.Data.Repositories
{
    public class HoraProjetoRepository : IHoraProjetoRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public HoraProjetoRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void Insert(HoraProjetoModel horaProjeto)
        {
            const string sql = @"insert into horaProjeto (id, id_projeto, id_colaborador, quantidade_hora, quantidade_minuto) values (@Id, @IdProjeto, @IdColaborador, @QuantidadeHora, @QuantidadeMinuto)";
            _databaseConnection._db.Execute(sql, new { Id = horaProjeto.Id, IdProjeto = horaProjeto.IdProjeto, IdColaborador = horaProjeto.IdColaborador, QuantidadeHora = horaProjeto.QuantidadeHora, QuantidadeMinuto = horaProjeto.QuantidadeMinuto }, commandType: CommandType.Text);
        }

        public void Update(HoraProjetoModel horaProjeto)
        {
            const string sql = @"update horaProjeto set id_projeto = @IdProjeto id_colaborador = @IdColaborador, quantidade_hora = @QuantidadeHora, quantidade_minuto = @QuantidadeMinuto where id = @Id";
            _databaseConnection._db.Execute(sql, new { Id = horaProjeto.Id, IdProjeto = horaProjeto.IdProjeto, IdColaborador = horaProjeto.IdColaborador, QuantidadeHora = horaProjeto.QuantidadeHora, QuantidadeMinuto = horaProjeto.QuantidadeMinuto }, commandType: CommandType.Text);
        }

        public void Delete(Guid horaProjetoId)
        {
             const string sql = @"delete from horaProjeto where id = @Id";
             _databaseConnection._db.Execute(sql, new { Id = horaProjetoId }, commandType: CommandType.Text);
        }

        public HoraProjetoModel SelectById(Guid idHoraProjeto)
        {
            const string sql = @"select id, id_projeto, id_colaborador, quantidade_hora, quantidade_minuto from horaProjeto where id = @Id";
            return _databaseConnection._db.Query<HoraProjetoModel>(sql, new { Id = idHoraProjeto }, commandType: CommandType.Text).FirstOrDefault();
        }
        public List<HoraProjetoModel> SelectByProjetoId(Guid idProjeto)
        {
            const string sql = @"select id, id_projeto, id_colaborador, quantidade_hora, quantidade_minuto from horaProjeto where id_projeto = @Id";
            return _databaseConnection._db.Query<HoraProjetoModel>(sql, new { Id = idProjeto }, commandType: CommandType.Text).ToList();
        }
        public List<HoraProjetoModel> SelectByEquipeId(Guid idEquipe)
        {
            const string sql = @"select id, id_projeto, id_colaborador, quantidade_hora, quantidade_minuto from horaProjeto where id_equipe = @Id";
            return _databaseConnection._db.Query<HoraProjetoModel>(sql, new { Id = idEquipe }, commandType: CommandType.Text).ToList();
        }
        public List<HoraProjetoModel> SelectAll()
        {
            const string sql = @"select id, id_projeto, id_colaborador, quantidade_hora, quantidade_minuto from horaProjeto";
            return _databaseConnection._db.Query<HoraProjetoModel>(sql, commandType: CommandType.Text).ToList();
        }
    }
}
