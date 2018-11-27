using Core.Application.Exceptions;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.WalletAccountCategories.Queries.GetDefaultWalletAccountCategory
{
    public class GetDefaultWalletAccountCategoryQueryHandler : IRequestHandler<GetDefaultWalletAccountCategoryQuery, WalletAccountCategory>
    {
        private readonly WalletDbContext _context;

        public GetDefaultWalletAccountCategoryQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<WalletAccountCategory> Handle(GetDefaultWalletAccountCategoryQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            return _context.WalletAccountCategories.SingleOrDefault(b => b.RegistrationDefault == true);
        }
    }
}
