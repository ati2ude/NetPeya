using Core.Application.Interfaces;
using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.TransactionStatuses.Commands.CreateTransactionStatus
{
    public class CreateTransactionStatusCommandHandler : IRequestHandler<CreateTransactionStatusCommand, TransactionStatus>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateTransactionStatusCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<TransactionStatus> Handle(CreateTransactionStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.TransactionStatuses.Where(e => e.Name == request.Name).FirstOrDefault();

            if (entity != null)
            {
                entity.statusCode = SharedStatusCodes.Exists;
                return entity;
            }

            var transactionStatus = new TransactionStatus
            {
                Name = request.Name
            };

            _context.TransactionStatuses.Add(transactionStatus);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                transactionStatus.statusCode = SharedStatusCodes.Created;
            }
            else
            {
                transactionStatus.statusCode = SharedStatusCodes.Failed;
            }

            return transactionStatus;
        }
    }
}
