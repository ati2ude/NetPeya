﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Users.Commands.CreateUser
{
    public class CreateWalletCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateWalletCommandValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(60);
            RuleFor(x => x.LastName).MaximumLength(60);
            RuleFor(x => x.Email).MaximumLength(60);

        }
    }
}
