using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.WalletAccountCategories.Queries.GetDefaultWalletAccountCategory
{
    public class GetDefaultWalletAccountCategoryQuery : IRequest<WalletAccountCategory>
    {
    }
}
