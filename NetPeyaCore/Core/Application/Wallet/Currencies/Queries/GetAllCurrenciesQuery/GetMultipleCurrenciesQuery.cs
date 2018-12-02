using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Currencies.Queries.GetAllCurrenciesQuery
{
    public class GetMultipleCurrenciesQuery : IRequest<List<Currency>>
    {
    }
}
