using Core.Application.Exceptions;
using Core.Application.StatusCodes;
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
            var bankAccountEntity = await _context.BankAccounts
                .FindAsync(request.BankAccountID);

            if (bankAccountEntity == null)
            {
                return new BankAccount { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            bankAccountEntity.statusCode = SharedStatusCodes.Retrieved;

            return bankAccountEntity;
        }
    }
}
