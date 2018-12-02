using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : User, IRequest<User>
    {
    }
}
