using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WalletApplication.User.Commands.CreateUser
{
    class CreateWalletUserCommandValidator : AbstractValidator<CreateWalletUserCommand>
    {
        public CreateWalletUserCommandValidator()
        {
            RuleFor(x => x.Id).Length(5).NotEmpty();
            RuleFor(x => x.FirstName).MaximumLength(60);
            RuleFor(x => x.LastName).MaximumLength(15);
            RuleFor(x => x.Email).MaximumLength(40).NotEmpty();
            RuleFor(x => x.Phone).MaximumLength(30);
            RuleFor(x => x.Password).MaximumLength(30);
            RuleFor(x => x.Country).MaximumLength(15);
            RuleFor(x => x.DefaultCurrency).MaximumLength(24);
        }
    }
}
