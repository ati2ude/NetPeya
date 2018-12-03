using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.SavedCards.Queries.GetSingleSavedCard
{
    public class GetSingleSavedCardQuery : SavedCard, IRequest<SavedCard>
    {
    }
}
