using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.CardTypes.Queries.GetAllCardTypes
{
    public class GetMultipleCardTypesQuery : IRequest<List<CardType>>
    {
    }
}
