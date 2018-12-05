using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.StatusCodes.Recipients;
using Core.Application.StatusCodes;

namespace Core.Application.Wallet.Recipients.Commands.CreateRecipient
{
    public class CreateRecipientCommandHandler : IRequestHandler<CreateRecipientCommand, Recipient>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateRecipientCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Recipient> Handle(CreateRecipientCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Email) && string.IsNullOrEmpty(request.Phone))
            {
                return new Recipient { statusCode = RecipientStatusCodes.MissingEmailandPhone };
            }

            var user = _context.Users.Where(e => e.ID == request.UserID ).FirstOrDefault();

            if (user == null)
            {
                return new Recipient { ID = 0, statusCode = SharedStatusCodes.UserNotFound };
            }

            var entity = _context.Recipients.Where(e => e.UserID == request.UserID && ((e.Email == request.Email && e.Email != null) || (e.Phone == request.Phone && e.Phone != null))).FirstOrDefault();

            if (entity != null)
            {
                entity.statusCode = SharedStatusCodes.Exists;
                return entity;
            }


            var recipientEntity = new Recipient
            {
                UserID = request.UserID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone
            };

            _context.Recipients.Add(recipientEntity);

            if(await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                recipientEntity.statusCode = SharedStatusCodes.Created;
            } else
            {
                recipientEntity.statusCode = SharedStatusCodes.Failed;
            }

            return recipientEntity;
        }
    }
}
