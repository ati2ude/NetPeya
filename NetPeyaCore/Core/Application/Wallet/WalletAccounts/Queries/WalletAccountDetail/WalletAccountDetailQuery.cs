using Core.Application.Wallet.WalletAccounts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.WalletAccounts.Queries
{
    public class WalletAccountDetailQuery : IRequest<WalletAccountDetailModel>
    {
        int _id;

        public int ID
        {
            get { return _id; }
            set { _id = Int32.Parse(value.ToString()); }
        }
    }
}
