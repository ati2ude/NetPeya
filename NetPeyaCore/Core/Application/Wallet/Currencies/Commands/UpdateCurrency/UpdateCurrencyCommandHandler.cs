using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Application.Wallet.Currencies.Commands.Models;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Currencies.Commands.UpdateCurrency
{
    public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand, Currency>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdateCurrencyCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Currency> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currencyEntity = _context.Currencies.SingleOrDefault(b => b.ID == request.ID);

            if (currencyEntity == null)
            {
                return new Currency { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            if (request.Name != null) currencyEntity.Name = request.Name;
            if (request.Code != null) currencyEntity.Code = request.Code;
            if (request.Symbol != null) currencyEntity.Symbol = request.Symbol;
        
            if (request.AddOnRegistration != null && request.AddOnRegistration == true)
            {
                foreach (var crr in _context.Currencies.Where(x => x.AddOnRegistration == true).ToList())
                {
                    crr.AddOnRegistration = false;
                }

                currencyEntity.AddOnRegistration = request.AddOnRegistration;
            }

            if (!_context.Entry(currencyEntity).Context.ChangeTracker.HasChanges())
            {
                currencyEntity.statusCode = SharedStatusCodes.Unchanged;
                return currencyEntity;
            }

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                currencyEntity.statusCode = SharedStatusCodes.Updated;
            }
            else
            {
                currencyEntity.statusCode = SharedStatusCodes.Failed;
            }

            return currencyEntity;
        }
    }
}
