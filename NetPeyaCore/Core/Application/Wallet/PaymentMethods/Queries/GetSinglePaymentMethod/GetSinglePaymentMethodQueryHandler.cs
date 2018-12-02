using Core.Application.Exceptions;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.PaymentMethods.Queries.GetSinglePaymentMethod
{
    public class GetSinglePaymentMethodQueryHandler : IRequestHandler<GetSinglePaymentMethodQuery, PaymentMethod>
    {
        private readonly WalletDbContext _context;

        public GetSinglePaymentMethodQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentMethod> Handle(GetSinglePaymentMethodQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.PaymentMethods
                .FindAsync(request.ID);

            if (entity == null)
            {
                return new PaymentMethod { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            entity.statusCode = SharedStatusCodes.Retrieved;

            return entity;
        }
    }
}
