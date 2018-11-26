using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Application.Wallet.Currencies.Commands.Models;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Currencies.Commands.UpdateCurrency
{
    public class UpdateCurrencyCommandHandler : IRequestHandler<CurrencyCommandRequestModel, Unit>
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

        public async Task<Unit> Handle(CurrencyCommandRequestModel request, CancellationToken cancellationToken)
        {
            var entity = _context.Currencies.SingleOrDefault(b => b.ID == request.ID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Currency), request.ID);
            }

            if (!string.IsNullOrEmpty(request.Name)) entity.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Code)) entity.Code = request.Code;
            if (!string.IsNullOrEmpty(request.Symbol)) entity.Symbol = request.Symbol;

            if (request.AddOnRegistration)
            {
                foreach (var crr in _context.Currencies.Where(x => x.AddOnRegistration == true).ToList())
                {
                    crr.AddOnRegistration = false;
                }
            }

            entity.AddOnRegistration = request.AddOnRegistration;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
