using Core.Application.Exceptions;
using Core.Application.Interfaces;
using Core.Domain.Wallet.Entities;
using Core.Persistence.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Core.Application.Wallet.Currencies.Commands.Models;
using Microsoft.EntityFrameworkCore;
using Core.Application.StatusCodes;

namespace Core.Application.Wallet.Currencies.Commands.CreateCurrency
{
    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, Currency>
    {
        private readonly WalletDbContext _context;
        private readonly INotificationService _notificationService;

        public CreateCurrencyCommandHandler(
            WalletDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Currency> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Currencies.SingleOrDefault(b => b.Code == request.Code);

            if (entity != null)
            {
                entity.statusCode = SharedStatusCodes.Exists;
                return entity;
            }

            var currencyEntity = new Currency
            {
                Name = request.Name,
                Symbol = request.Symbol,
                Code = request.Code,
                AddOnRegistration = request.AddOnRegistration
            };

            _context.Currencies.Add(currencyEntity);

            if(await _context.SaveChangesAsync(cancellationToken) > 0)
            {
                currencyEntity.statusCode = SharedStatusCodes.Created;
            }
            else
            {
                currencyEntity.statusCode = SharedStatusCodes.Failed;
            }

            return currencyEntity;
        }
    }
}
