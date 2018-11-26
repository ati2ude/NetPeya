using Core.Application.Wallet.Currencies.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Currencies.Commands.CreateCurrency
{
    public class CurrencyCommandValidator : AbstractValidator<CreateCurrencyCommand>
    {
        public CurrencyCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(60);
            RuleFor(x => x.Code).MaximumLength(3);
            RuleFor(x => x.Symbol).MaximumLength(1);

        }
    }
}
