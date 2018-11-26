using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Currencies.Queries.GetSingleCurrency
{
    public class GetSingleCurrencyQuery : IRequest<Currency>
    {
        int _currencyID;

        public int CurrencyID
        {
            get { return _currencyID; }
            set { _currencyID = Int32.Parse(value.ToString()); }
        }
    }
}
