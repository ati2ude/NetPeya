using Core.Domain.Wallet.Entities;
using MediatR;

namespace Core.Application.Wallet.Recipients.Models
{
    public class BaseRecipientCommand : Recipient, IRequest<Recipient>
    {
    }
}
