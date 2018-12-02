using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateUserCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User
            {
                CountryID = request.CountryID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone,
                DateOfBirth = request.DateOfBirth,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                IsActive = false
            };

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
