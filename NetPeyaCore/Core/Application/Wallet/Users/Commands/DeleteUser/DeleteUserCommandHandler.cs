using Core.Application.Interfaces;
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

namespace Core.Application.Wallet.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public DeleteUserCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Users.SingleOrDefault(x => x.ID == request.ID);

            if(entity == null)
            {
                return new User { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            _context.Users.Remove(entity);

            // TO DO - remove other entities associated with this user

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
