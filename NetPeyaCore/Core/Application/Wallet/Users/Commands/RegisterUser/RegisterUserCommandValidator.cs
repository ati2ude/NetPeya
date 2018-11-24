using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Users.Commands.RegisterUser
{
    public class RegisterCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(60);
            RuleFor(x => x.LastName).MaximumLength(60);
            RuleFor(x => x.Email).MaximumLength(60);

        }
    }
}
