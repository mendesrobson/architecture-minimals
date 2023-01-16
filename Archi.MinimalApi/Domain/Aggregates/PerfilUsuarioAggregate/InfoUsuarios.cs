using Domain.Exceptions;
using Domain.Validators.UsuarioPerfilValidate;

namespace Domain.Aggregates.PerfilUsuarioAggregate
{
    public class InfoUsuarios
    {
        public InfoUsuarios(string nome, 
                         string sobreNome, 
                         string email, 
                         string telefone)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            Telefone = telefone;
        }

        private InfoUsuarios() {}

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public static InfoUsuarios CreateUsuarioInfo(string nome,
                                                        string sobreNome,
                                                        string email,
                                                        string telefone)
        {
            UsuarioValidate validations = new();

            InfoUsuarios usuario = new()
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
