using Core.Application.Exceptions;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.BankAccounts.Queries.GetSingleBankAccount
{
    public class GetSingleBankAccountQueryHandler : IRequestHandler<GetSingleBankAccountQuery, BankAccount>
    {
        private readonly WalletDbContext _context;
        
        public GetSingleBankAccountQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<BankAccount> Handle(GetSingleBankAccountQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.BankAccounts
                .FindAsync(request.BankAccountID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Currency), request.BankAccountID);
            }

            return entity;
        }
    }
}
