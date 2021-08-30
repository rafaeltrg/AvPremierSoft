using System;
using System.Collections.Generic;
using System.Text;

namespace AVPremierSoft.Domain.Usuario.Model
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set { _senha = EncryptPassword(value); }
        }

        private string EncryptPassword(string senha)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(senha);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
    }
}
