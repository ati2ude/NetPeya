using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Currencies.Commands.CreateCurrency
{
    public class CreateCurrencyCommandValidator : AbstractValidator<CreateCurrencyCommand>
    {
        public CreateCurrencyCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60);
            RuleFor(x => x.Code).MaximumLength(3);
            RuleFor(x => x.Symbol).MaximumLength(1);

        }
    }
}
