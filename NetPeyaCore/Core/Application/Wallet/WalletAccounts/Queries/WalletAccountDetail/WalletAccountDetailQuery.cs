using Core.Application.Wallet.WalletAccounts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.WalletAccounts.Queries
{
    public class WalletAccountDetailQuery : WalletAccountDetailModel, IRequest<WalletAccountDetailModel>
    {
    }
}
