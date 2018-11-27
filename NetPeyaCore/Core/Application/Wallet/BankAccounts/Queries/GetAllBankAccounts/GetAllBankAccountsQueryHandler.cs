using Core.Application.Wallet.Currencies.Queries.GetAllCurrenciesQuery;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.BankAccounts.Queries.GetAllBankAccounts
{
    class GetAllBankAccountsQueryHandler : IRequestHandler<GetAllBankAccountsQuery, List<BankAccount>>
    {
        private readonly WalletDbContext _context;

        public GetAllBankAccountsQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<BankAccount>> Handle(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            var accounts = _context.BankAccounts.Where(x => x.UserID == request.UserID).ToList();

            return accounts;
        }
    }
}
