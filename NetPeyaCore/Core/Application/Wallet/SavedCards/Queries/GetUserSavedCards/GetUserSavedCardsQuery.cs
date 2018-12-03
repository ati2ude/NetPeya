using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.SavedCards.Queries.GetUserSavedCards
{
    public class GetUserSavedCardsQuery : SavedCard, IRequest<List<SavedCard>>
    {
        public new int? UserID { get; set; }
    }
}
