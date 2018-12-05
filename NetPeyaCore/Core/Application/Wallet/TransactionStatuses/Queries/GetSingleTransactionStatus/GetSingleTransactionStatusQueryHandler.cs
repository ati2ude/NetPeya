using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.TransactionStatuses.Queries.GetSingleTransactionStatus
{
    public class GetSingleTransactionStatusQueryHandler : IRequestHandler<GetSingleTransactionStatusQuery, TransactionStatus>
    {
        private readonly WalletDbContext _context;

        public GetSingleTransactionStatusQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionStatus> Handle(GetSingleTransactionStatusQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.TransactionStatuses
                .FindAsync(request.ID);

            if (entity == null)
            {
                return new TransactionStatus { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            entity.statusCode = SharedStatusCodes.Retrieved;

            return entity;
        }
    }
}
