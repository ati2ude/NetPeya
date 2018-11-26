using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Core.Application.Wallet.Currencies.Commands.CreateCurrency
{
    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, Unit>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateCurrencyCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = (
                from c in _context.Currencies
                where c.Code == request.Code
                select new
                    {
                        c.ID,
                        c.Name,
                        c.Symbol,
                        c.Code
                    }
            ).FirstOrDefault();
                

            if (entity != null)
            {
                throw new DuplicateEntriesException(nameof(Currency), request.Code);
            }

            var currencyEntity = new Currency
            {
                Name = request.Name,
                Symbol = request.Symbol,
                Code = request.Code,
                AddOnRegistration =request.AddOnRegistration
            };

            _context.Currencies.Add(currencyEntity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
