using Domain.Aggregates.PerfilUsuarioAggregate;
using FluentValidation;
using System;

namespace Domain.Validators.UsuarioPerfilValidate
{
    public class UsuarioValidate: AbstractValidator<UsuariosInfo>
    {
        public UsuarioValidate()
        {
            RuleFor(_ => _.Nome)
                .NotNull().WithMessage("O 'Nome' não pode ser nulo")
                .MinimumLength(3).WithMessage("O 'Nome' deve contar mais de 3 caracter.")
                .MaximumLength(50).WithMessage("'Nome' nãpo pode conter mais de 50 caracter.");

            RuleFor(_ => _.SobreNome)
               .NotNull().WithMessage("O 'SobreNome' não pode ser nulo")
               .MinimumLength(3).WithMessage("O 'SobreNome' deve contar mais de 3 caracter.")
               .MaximumLength(50).WithMessage("O 'SobreNome' nãpo pode conter mais de 50 caracter.");

            RuleFor(_ => _.Email)
              .NotNull().WithMessage("O 'Email' não pode ser nulo")
              .EmailAddress().WithMessage("O valor fornecido não corresponde a um email valido.");
        }
    }
}
