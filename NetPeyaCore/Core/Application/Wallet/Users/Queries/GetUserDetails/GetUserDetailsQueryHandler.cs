using Core.Application.Exceptions;
using Core.Application.Wallet.Users.Models;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Wallet.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsModel>
    {
        private readonly WalletDbContext _context;

        public GetUserDetailsQueryHandler(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<UserDetailsModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(request.UserID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserID);
            }

            var queryEntry = (
                from u in _context.Users
                join c in _context.Countries
                on u.CountryID equals c.ID
                where u.ID == request.UserID
                select new
                {
                    u.ID,
                    u.FirstName,
                    u.LastName,
                    u.Email,
                    u.Phone,
                    u.DateOfBirth,
                    u.AddressLine1,
                    u.AddressLine2,
                    u.IsActive,
                    Country = c

                }).First();

            return new UserDetailsModel
            {
                UserID = queryEntry.ID,
                Country = queryEntry.Country,
                FirstName = queryEntry.FirstName,
                LastName = queryEntry.LastName,
                Email = queryEntry.Email,
                Phone = queryEntry.Phone,
                DateOfBirth = queryEntry.DateOfBirth,
                AddressLine1 = queryEntry.AddressLine1,
                AddressLine2 = queryEntry.AddressLine2,
                IsActive = queryEntry.IsActive
            };
        }
    }
}
