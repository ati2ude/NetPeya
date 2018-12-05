using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.TransactionStatuses.Queries.GetAllTransactionStatuses
{
    public class GetAllTransactionStatusesQuery : TransactionStatus, IRequest<List<TransactionStatus>>
    {
    }
}
