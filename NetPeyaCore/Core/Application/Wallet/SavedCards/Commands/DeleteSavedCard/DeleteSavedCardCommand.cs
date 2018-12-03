using Core.Application.Wallet.SavedCards.Models;
using Core.Domain.Wallet.Entities;
using MediatR;

namespace Core.Application.Wallet.SavedCards.Commands.DeleteSavedCard
{
    public class DeleteSavedCardCommand : BaseSavedCardCommand, IRequest<SavedCard>
    {
    }
}
