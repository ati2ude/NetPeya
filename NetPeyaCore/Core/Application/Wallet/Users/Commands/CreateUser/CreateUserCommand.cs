using Core.Domain.Wallet.Entities;
using MediatR;

namespace Core.Application.Wallet.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public int? ID { get; set; }
        public int DefaultCurrency { get; set; } // TO-DO use a currency entity
        public int CountryID { get; set; } // TO_DO use a country entity
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

