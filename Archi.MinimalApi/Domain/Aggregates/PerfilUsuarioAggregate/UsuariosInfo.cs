using Domain.Exceptions;
using Domain.Validators.UsuarioPerfilValidate;

namespace Domain.Aggregates.PerfilUsuarioAggregate
{
    public class UsuariosInfo
    {
        public UsuariosInfo(string nome, 
                               string sobreNome, 
                               string email, 
                               string telefone)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            Telefone = telefone;
        }

        private UsuariosInfo() {}

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public static UsuariosInfo CreateUsuarioInfo(string nome,
                                                        string sobreNome,
                                                        string email,
                                                        string telefone)
        {
            UsuarioValidate validations = new();

            UsuariosInfo usuario = new()
            {
                Nome= nome,
                SobreNome= sobreNome,
                Email= email,
                Telefone = telefone
            };

            var valid = validations.Validate(usuario);

            if (valid.IsValid) return usuario;

            var exception = new UsuarioPerfilNotifException("O UsuarioPerfil não e valido.");

            foreach(var erro in valid.Errors)
            {
                exception.ValidationErrors.Add(erro.ErrorMessage);
            }

            throw exception;
        }
    }
}
