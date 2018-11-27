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
    public class GetAllCardTypesQueryHandler : IRequestHandler<GetAllCardTypesQuery, List<CardType>>
    {
        private readonly WalletDbContext _context;

        public GetAllCardTypesQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<CardType>> Handle(GetAllCardTypesQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            var cardtypes = _context.CardTypes.ToList();

            return cardtypes;
        }
    }
}
