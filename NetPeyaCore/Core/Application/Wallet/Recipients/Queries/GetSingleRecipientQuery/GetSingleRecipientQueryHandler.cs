using Core.Application.StatusCodes;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Recipients.Queries.GetSingleRecipientQuery
{
    public class GetSingleRecipientQueryHandler : IRequestHandler<GetSingleRecipientQuery, Recipient>
    {
        private readonly WalletDbContext _context;

        public GetSingleRecipientQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<Recipient> Handle(GetSingleRecipientQuery request, CancellationToken cancellationToken)
        {
            var recipientEntity = await _context.Recipients
                .FindAsync(request.ID);

            if (recipientEntity == null)
            {
                return new Recipient { ID = 0, statusCode = SharedStatusCodes.NotFound };
            }

            recipientEntity.statusCode = SharedStatusCodes.Retrieved;

            return recipientEntity;
        }
    }
}
