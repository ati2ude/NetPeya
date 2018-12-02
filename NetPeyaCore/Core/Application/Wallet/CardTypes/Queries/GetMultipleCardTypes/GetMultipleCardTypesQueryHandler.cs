using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.CardTypes.Queries.GetAllCardTypes
{
    public class GetMultipleCardTypesQueryHandler : IRequestHandler<GetMultipleCardTypesQuery, List<CardType>>
    {
        private readonly WalletDbContext _context;

        public GetMultipleCardTypesQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<CardType>> Handle(GetMultipleCardTypesQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            var cardTypes = _context.CardTypes.ToList();

            cardTypes.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;

            return cardTypes;
        }
    }
}
