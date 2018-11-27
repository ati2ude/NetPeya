using Core.Domain.Wallet.Entities;
using MediatR;
using System;

namespace Core.Application.Wallet.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest
    {
        // For User Entity
        public int CountryID { get; set; } // TO_DO use a country entity
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        // For WalletAccount Entity
        public int CurrencyID { get; set; }
    }
}

