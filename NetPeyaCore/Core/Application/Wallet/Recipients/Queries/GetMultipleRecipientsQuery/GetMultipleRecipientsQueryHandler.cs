using Core.Application.StatusCodes;
using Core.Application.StatusCodes.Recipients;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Recipients.Queries.GetMultipleRecipientsQuery
{
    public class GetMultipleRecipientsQueryHandler : IRequestHandler<GetMultipleRecipientsQuery, List<Recipient>>
    {
        private readonly WalletDbContext _context;

        public GetMultipleRecipientsQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<Recipient>> Handle(GetMultipleRecipientsQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            List<Recipient> recipients;

            if (request.UserID != null)
            {
                recipients = _context.Recipients.Where(x => x.UserID == request.UserID).ToList();
                recipients.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;
            } else
            {
                recipients = _context.Recipients.ToList();
                recipients.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;
            }

            return recipients;
        }
    }
}
