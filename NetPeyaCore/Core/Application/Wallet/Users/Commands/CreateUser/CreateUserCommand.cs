﻿using Core.Domain.Wallet.Entities;
using MediatR;
using System;

namespace Core.Application.Wallet.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public int ID { get; set; }
        public int CountryID { get; set; } // TO_DO use a country entity
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

