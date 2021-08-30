using AVPremierSoft.Domain.Usuario.Model;


namespace AVPremierSoft.Domain.Usuario.Interface
{
    public interface IUsuarioService
    {
        void InsertUsuario(UsuarioModel usuario);
        void UpdateUsuario(UsuarioModel usuario);
        string AuthenticateUsuario(string email, string senha);
    }
}
