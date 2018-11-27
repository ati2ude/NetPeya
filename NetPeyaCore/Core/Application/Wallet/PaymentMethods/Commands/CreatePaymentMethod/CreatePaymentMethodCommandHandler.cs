using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.PaymentMethods.Commands.CreatePaymentMethod
{
    public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, PaymentMethod>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreatePaymentMethodCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<PaymentMethod> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.PaymentMethods.SingleOrDefault(b => b.Name == request.Name);

            if (entity != null)
            {
                throw new DuplicateEntriesException(nameof(PaymentMethod), request.Name);
            }

            var methodEntity = new PaymentMethod
            {
                Name = request.Name,
                Icon = request.Icon,
                ExternalCharges = request.ExternalCharges,
                InternalCharges = request.InternalCharges,
                AllowDeposit = request.AllowDeposit,
                AllowTransfer = request.AllowTransfer,
                AllowWithdrawal = request.AllowWithdrawal
            };

            _context.PaymentMethods.Add(methodEntity);

            await _context.SaveChangesAsync(cancellationToken);

            return methodEntity;
        }
    }
}
