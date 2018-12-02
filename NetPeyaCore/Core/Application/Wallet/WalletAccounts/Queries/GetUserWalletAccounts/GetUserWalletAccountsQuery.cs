using Core.Application.Wallet.WalletAccounts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.WalletAccounts.Queries.GetUserWalletAccounts
{
    public class GetUserWalletAccountsQuery : IRequest<List<WalletAccountDetailModel>>
    {
        public int? UserID { get; set; }
    }
}
