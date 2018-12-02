using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Countries.Models
{
    public class BaseCountryCommand : Country, IRequest<Country>
    {
    }
}
