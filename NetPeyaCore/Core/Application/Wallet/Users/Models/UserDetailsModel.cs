using Core.Domain.Wallet.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Users.Models
{
    public class UserDetailsModel
    {
        public int UserID { get; set; }
        public Country Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public bool IsActive { get; set; }
    }
}
