using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Recipients.Commands.DeleteRecipient
{
    public class DeleteRecipientCommandHandler : IRequestHandler<DeleteRecipientCommand, Recipient>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public DeleteRecipientCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Recipient> Handle(DeleteRecipientCommand request, CancellationToken cancellationToken)
        {
            var recipientEntity = await _context.Recipients
                .FindAsync(request.ID);

            if (recipientEntity == null)
            {
                return new Recipient { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            _context.Recipients.Remove(recipientEntity);

            if(await _context.SaveChangesAsync() > 0)
            {
                recipientEntity.statusCode = SharedStatusCodes.Deleted;
            } else
            {
                recipientEntity.statusCode = SharedStatusCodes.Failed;
            }

            return recipientEntity;
        }
    }
}
