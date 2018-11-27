using Core.Application.Wallet.Countries.Commands;
using Core.Application.Wallet.Users.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Countries.Commands
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60);
            RuleFor(x => x.Code).MaximumLength(5);
        }
    }
}
