namespace WebApiMinimal.Validators;

public class UsuarioPerfilUpdateValidate : AbstractValidator<UsuarioPerfilCreateUpdate>
{
    public UsuarioPerfilUpdateValidate()
    {
        RuleFor(_ => _.Email)
            .NotEmpty()
            .NotNull();

        RuleFor(_ => _.Nome)
            .NotEmpty()
            .NotNull();

        RuleFor(_ => _.SobreNome)
            .NotEmpty()
            .NotNull();
    }
}
