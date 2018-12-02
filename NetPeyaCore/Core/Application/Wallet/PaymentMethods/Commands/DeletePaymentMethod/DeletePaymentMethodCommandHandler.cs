using Core.Application.Exceptions;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.PaymentMethods.Commands.DeletePaymentMethod
{
    public class DeletePaymentMethodCommandHandler : IRequestHandler<DeletePaymentMethodCommand, PaymentMethod>
    {
        private readonly WalletDbContext _context;

        public DeletePaymentMethodCommandHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentMethod> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PaymentMethods
                .FindAsync(request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PaymentMethod), request.ID);
            }

            _context.PaymentMethods.Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
