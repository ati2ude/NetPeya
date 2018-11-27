using Core.Domain.Wallet.Entities;
using MediatR;
using System;

namespace Core.Application.Wallet.Users.Commands.CreateUser
{
    public class CreateUserCommand : User, IRequest<User>
    {
    }
}

