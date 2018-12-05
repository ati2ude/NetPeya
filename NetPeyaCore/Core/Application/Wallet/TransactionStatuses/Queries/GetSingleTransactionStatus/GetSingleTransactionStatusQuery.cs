using Core.Domain.Wallet.Entities;
using MediatR;

namespace Core.Application.Wallet.TransactionStatuses.Queries.GetSingleTransactionStatus
{
    public class GetSingleTransactionStatusQuery : TransactionStatus, IRequest<TransactionStatus>
    {
    }
}
