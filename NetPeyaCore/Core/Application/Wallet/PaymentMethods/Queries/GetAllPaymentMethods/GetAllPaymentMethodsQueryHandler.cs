using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.PaymentMethods.Queries.GetAllPaymentMethods
{
    public class GetAllPaymentMethodsQueryHandler : IRequestHandler<GetAllPaymentMethodsQuery, List<PaymentMethod>>
    {
        private readonly WalletDbContext _context;

        public GetAllPaymentMethodsQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentMethod>> Handle(GetAllPaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            var methods = _context.PaymentMethods.ToList();

            return methods;
        }
    }
}
