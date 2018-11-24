using Core.Application.Exceptions;
using Core.Application.Wallet.WalletAccounts.Models;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.WalletAccounts.Queries
{
    public class WalletAccountDetailQueryHandler : IRequestHandler<WalletAccountDetailQuery, WalletAccountDetailModel>
    {
        private readonly WalletDbContext _context;

        public WalletAccountDetailQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<WalletAccountDetailModel> Handle(WalletAccountDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.WalletAccounts
                .FindAsync(request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(WalletAccount), request.ID);
            }

            var queryEntry = (
                from wa in _context.WalletAccounts
                join wac in _context.WalletAccountCategories
                on wa.WalletAccountCategoryID equals wac.ID
                join c in _context.Currencies
                on wa.CurrencyID equals c.ID
                where wa.ID == request.ID
                select new
                {
                    wa.ID,
                    wa.UserID,
                    wa.Name,
                    wa.WalletAccountCode,
                    wa.Balance,
                    wa.IsDefault,
                    CurrencyCode = c.Code,
                    CurrencySymbol = c.Symbol,
                    WalletAccountCategory = wac.Name

                }).First();

            return new WalletAccountDetailModel
            {
                ID = queryEntry.ID,
                UserID = queryEntry.UserID,
                CurrencyCode = queryEntry.CurrencyCode,
                CurrencySymbol = queryEntry.CurrencySymbol,
                WalletAccountCategory = queryEntry.WalletAccountCategory,
                WalletAccountCode = queryEntry.WalletAccountCode,
                Name = queryEntry.Name,
                Balance = queryEntry.Balance,
                IsDefault = queryEntry.IsDefault
            };
        }
    }
}
