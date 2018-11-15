using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateUserCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User
            {
                UserID = request.UserID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CurrencyID = request.CurrencyID,
                CountryID = request.CountryID
            };

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
