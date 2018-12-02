using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.WalletAccounts.Models
{
    public class BaseWalletAccountCommand : WalletAccount, IRequest<WalletAccount>
    {
    }
}
