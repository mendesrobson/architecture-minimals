using Domain.Exceptions;
using Domain.Validators.UsuarioPerfilValidate;

namespace Domain.Aggregates.PerfilUsuarioAggregate
{
    public class UsuarioInfoBase
    {
        public UsuarioInfoBase(string nome, 
                               string sobreNome, 
                               string email, 
                               string telefone)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            Telefone = telefone;
        }

        private UsuarioInfoBase() {}

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public static UsuarioInfoBase CreateUsuarioInfo(string nome,
                                                        string sobreNome,
                                                        string email,
                                                        string telefone)
        {
            UsuarioPerfilValidate validations = new();

            UsuarioInfoBase usuario = new()
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
