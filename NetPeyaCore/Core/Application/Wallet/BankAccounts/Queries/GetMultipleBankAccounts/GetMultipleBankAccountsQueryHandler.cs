using Core.Application.StatusCodes;
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
    class GetMultipleBankAccountsQueryHandler : IRequestHandler<GetMultipleBankAccountsQuery, List<BankAccount>>
    {
        private readonly WalletDbContext _context;

        public GetMultipleBankAccountsQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<BankAccount>> Handle(GetMultipleBankAccountsQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            List<BankAccount> accounts;

            if (request.UserID != null)
            {
                accounts = _context.BankAccounts.Where(x => x.UserID == request.UserID).ToList();
            }
            else
            {
                accounts = _context.BankAccounts.ToList();
            }

            if (accounts.Count > 0)
            {
                accounts.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;
            }

            return accounts;
        }
    }
}
