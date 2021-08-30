using AVPremierSoft.Domain.Colaborador.Interface;
using AVPremierSoft.Domain.Colaborador.Model;
using AVPremierSoft.Domain.Token.Interface;
using AVPremierSoft.Domain.Usuario.Interface;
using AVPremierSoft.Domain.Usuario.Model;

namespace AVPremierSoft.Domain.Usuario.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        private readonly IColaboradorRepository _colaboradorRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService, IColaboradorRepository colaboradorRepository)
        {
            _usuarioRepository = usuarioRepository;
            _colaboradorRepository = colaboradorRepository;
            _tokenService = tokenService;

        }

        public void InsertUsuario(UsuarioModel usuario)
        {
            _usuarioRepository.Insert(usuario);
        }

        public void UpdateUsuario(UsuarioModel usuario)
        {
            _usuarioRepository.Update(usuario);
        }
        public string AuthenticateUsuario(string email, string senha)
        {
            //var user = _usuarioRepository.SelectByEmailSenha(email, senha);

            var user = new UsuarioModel { Id = new System.Guid(), Email = "email", Senha = "senha" };

            //var colaborador = _colaboradorRepository.SelectByEmail(email);
            var colaborador = new ColaboradorModel { Id = new System.Guid(), IdEquipe = new System.Guid(), IdUsuario = new System.Guid(), Nome = "bruno", Role = "gestor", Telefone = "696969" };

            if (user == null)
                return string.Empty;

            return _tokenService.GenerateToken(user, colaborador.Role);
        }
    }
}
