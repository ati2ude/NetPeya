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

namespace Core.Application.Wallet.TransactionStatuses.Queries.GetAllTransactionStatuses
{
    public class GetAllTransactionStatusesQueryHandler : IRequestHandler<GetAllTransactionStatusesQuery, List<TransactionStatus>>
    {
        private readonly WalletDbContext _context;

        public GetAllTransactionStatusesQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionStatus>> Handle(GetAllTransactionStatusesQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();

            List<TransactionStatus> statuses = _context.TransactionStatuses.ToList();

            if (statuses.Count > 0)
            {
                statuses.FirstOrDefault().statusCode = SharedStatusCodes.Retrieved;
            }

            return statuses;
        }
    }
}
