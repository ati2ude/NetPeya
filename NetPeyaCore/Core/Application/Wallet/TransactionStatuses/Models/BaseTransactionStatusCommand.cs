using Core.Domain.Wallet.Entities;
using MediatR;

namespace Core.Application.Wallet.TransactionStatuses.Models
{
    public class BaseTransactionStatusCommand : TransactionStatus, IRequest<TransactionStatus>
    {
    }
}
