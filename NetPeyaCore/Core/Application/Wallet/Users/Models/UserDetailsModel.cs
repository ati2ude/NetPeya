using Core.Domain.Wallet.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Application.Wallet.Users.Models
{
    public class UserDetailsModel : User
    {
        public int UserID { get; set; }
        public Country Country { get; set; }
    }
}
