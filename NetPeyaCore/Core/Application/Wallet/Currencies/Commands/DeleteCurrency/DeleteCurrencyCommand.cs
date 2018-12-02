using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Currencies.Commands.DeleteCurrency
{
    public class DeleteCurrencyCommand : Currency, IRequest<Currency>
    {
    }
}
