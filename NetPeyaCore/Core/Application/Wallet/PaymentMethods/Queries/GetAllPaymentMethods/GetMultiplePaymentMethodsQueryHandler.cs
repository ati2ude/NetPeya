using Core.Application.StatusCodes;
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
    public class GetMultiplePaymentMethodsQueryHandler : IRequestHandler<GetMultiplePaymentMethodsQuery, List<PaymentMethod>>
    {
        private readonly WalletDbContext _context;

        public GetMultiplePaymentMethodsQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaymentMethod>> Handle(GetMultiplePaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            List<PaymentMethod> methods = _context.PaymentMethods.ToList();

            if (methods.Count > 0)
            {
                methods.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;
            }

            return methods;
        }
    }
}
