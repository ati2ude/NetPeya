using Core.Domain.Wallet.Entities;
using MediatR;
using System;

namespace Core.Application.Wallet.Countries.Commands
{
    public class CreateCountryCommand : Country, IRequest<Country>
    {
    }
}

