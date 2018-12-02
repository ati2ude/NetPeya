using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.PaymentMethods.Commands.UpdatePaymentMethod
{
    public class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommand, PaymentMethod>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdatePaymentMethodCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<PaymentMethod> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.PaymentMethods.SingleOrDefault(b => b.ID == request.ID);

            if (entity == null)
            {
                return new PaymentMethod { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            if (entity.Name != request.Name) entity.Name = request.Name;
            if (entity.Icon != request.Icon) entity.Icon = request.Icon;
            if (request.ExternalCharges != null) entity.ExternalCharges = request.ExternalCharges;
            if (request.InternalCharges != null) entity.InternalCharges = request.InternalCharges;
            if (request.AllowDeposit != null) entity.AllowDeposit = request.AllowDeposit;
            if (request.AllowTransfer != null) entity.AllowTransfer = request.AllowTransfer;
            if (request.AllowWithdrawal != null) entity.AllowWithdrawal = request.AllowWithdrawal;

            if (!_context.Entry(entity).Context.ChangeTracker.HasChanges())
            {
                entity.statusCode = SharedStatusCodes.Unchanged;
                return entity;
            }

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                entity.statusCode = SharedStatusCodes.Updated;
            }
            else
            {
                entity.statusCode = SharedStatusCodes.Failed;
            }

            return entity;
        }
    }
}
