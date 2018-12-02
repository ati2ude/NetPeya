using Core.Domain.Wallet.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.Wallet.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<User>
    {
        // For User Entity
        [Required]
        public int CountryID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        // For WalletAccount Entity
        [Required]
        public int CurrencyID { get; set; }
    }
}

