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

namespace Core.Application.Wallet.WalletAccounts.Queries.GetUserWalletAccounts
{
    public class GetUserWalletAccountsQueryHandler : IRequestHandler<GetUserWalletAccountsQuery, List<WalletAccountDetailModel>>
    {
        private readonly WalletDbContext _context;

        public GetUserWalletAccountsQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<WalletAccountDetailModel>> Handle(GetUserWalletAccountsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(request.UserID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserID);
            }

            var waletsDbEntries = (
                from wa in _context.WalletAccounts
                join wac in _context.WalletAccountCategories
                on wa.WalletAccountCategoryID equals wac.ID
                join c in _context.Currencies
                on wa.CurrencyID equals c.ID
                where wa.UserID == request.UserID
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

                }).ToList();

            List<WalletAccountDetailModel> walletDetailsList = new List<WalletAccountDetailModel>();


            foreach (var walletDetail in waletsDbEntries)
            {
                walletDetailsList.Add(
                    new WalletAccountDetailModel
                    {
                        ID = walletDetail.ID,
                        UserID = walletDetail.UserID,
                        CurrencyCode = walletDetail.CurrencyCode,
                        CurrencySymbol = walletDetail.CurrencySymbol,
                        WalletAccountCategory = walletDetail.WalletAccountCategory,
                        WalletAccountCode = walletDetail.WalletAccountCode,
                        Name = walletDetail.Name,
                        Balance = walletDetail.Balance,
                        IsDefault = walletDetail.IsDefault
                    }
                );
            }

            return walletDetailsList;
        }
    }
}
