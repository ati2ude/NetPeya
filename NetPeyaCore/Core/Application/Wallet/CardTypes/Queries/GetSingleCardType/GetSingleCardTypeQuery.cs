using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.CardTypes.Queries.GetSingleCardType
{
    public class GetSingleCardTypeQuery : IRequest<CardType>
    {
        int _id;

        public int ID
        {
            get { return _id; }
            set { _id = Int32.Parse(value.ToString()); }
        }
    }
}
