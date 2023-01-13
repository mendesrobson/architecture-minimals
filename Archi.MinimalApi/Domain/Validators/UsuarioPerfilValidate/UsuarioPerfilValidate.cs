using Domain.Aggregates.PerfilUsuarioAggregate;
using FluentValidation;
using System;

namespace Domain.Validators.UsuarioPerfilValidate
{
    public class UsuarioPerfilValidate: AbstractValidator<UsuarioInfoBase>
    {
        public UsuarioPerfilValidate()
        {

        }
    }
}
