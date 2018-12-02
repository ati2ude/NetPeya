using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Recipients.Queries.GetMultipleRecipientsQuery
{
    public class GetMultipleRecipientsQuery : IRequest<List<Recipient>>
    {
        public int? UserID { get; set; }
    }
}
