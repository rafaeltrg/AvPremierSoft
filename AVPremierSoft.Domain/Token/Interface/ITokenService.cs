using AVPremierSoft.Domain.Usuario.Model;

namespace AVPremierSoft.Domain.Token.Interface
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioModel usuario, string role);
    }
}
