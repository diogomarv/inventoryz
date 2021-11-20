using FluentValidation;
using InventoryZ.Application.Commands.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryZ.Application.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Senha inválida. Sua senha precisa ter no mínimo um caractere maiúsculo, uma minúscula e no mínimo um número.");
        }

    }
}
