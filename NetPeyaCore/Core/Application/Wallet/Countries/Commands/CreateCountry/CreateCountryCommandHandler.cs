using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Countries.Commands
{
    public class CreateCoutrnyCommandHandler : IRequestHandler<CreateCountryCommand, Unit>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateCoutrnyCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Country
            {
                ID = request.ID,
                DefaultCurrency = request.DefaultCurrency,
                Name = request.Name,
                Code = request.Code
            };

            _context.Countries.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
