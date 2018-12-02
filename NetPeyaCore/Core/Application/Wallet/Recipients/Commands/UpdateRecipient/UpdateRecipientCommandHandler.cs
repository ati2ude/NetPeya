using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Recipients.Commands.UpdateRecipient
{
    public class UpdateRecipientCommandHandler : IRequestHandler<UpdateRecipientCommand, Recipient>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public UpdateRecipientCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Recipient> Handle(UpdateRecipientCommand request, CancellationToken cancellationToken)
        {
            var recipientEntity = _context.Recipients.SingleOrDefault(b => b.ID == request.ID);

            if (recipientEntity == null)
            {
                return new Recipient { ID = 0, statusCode = SharedStatusCodes.NotFound};
            }

            if (recipientEntity.FirstName != request.FirstName) recipientEntity.FirstName = request.FirstName;
            if (recipientEntity.LastName != request.LastName) recipientEntity.LastName = request.LastName;
            if (request.Email != null) recipientEntity.Email = request.Email;
            if (request.Phone != null) recipientEntity.Phone = request.Phone;



            if (!_context.Entry(recipientEntity).Context.ChangeTracker.HasChanges())
            {
                recipientEntity.statusCode = SharedStatusCodes.Unchanged;
                return recipientEntity;
            }

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                recipientEntity.statusCode = SharedStatusCodes.Updated;
            } else
            {
                recipientEntity.statusCode = SharedStatusCodes.Failed;
            }

            return recipientEntity;
        }
    }
}
