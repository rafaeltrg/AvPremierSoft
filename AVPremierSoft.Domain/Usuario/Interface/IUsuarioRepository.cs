using AVPremierSoft.Domain.Usuario.Model;
using System;


namespace AVPremierSoft.Domain.Usuario.Interface
{
    public interface IUsuarioRepository
    {
        void Insert(UsuarioModel usuario);
        void Update(UsuarioModel usuario);
        void Delete(Guid usuarioId);
        UsuarioModel SelectByEmailSenha(string email, string senha);
    }
}
