using Core.Application.Wallet.Users.Models;
using Core.Domain.Wallet.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.Wallet.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : User, IRequest<User>
    {
        public int CurrencyID { get; set; }
    }
}

