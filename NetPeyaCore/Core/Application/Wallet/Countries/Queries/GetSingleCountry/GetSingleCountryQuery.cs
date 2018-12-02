using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Countries.Queries
{
    public class GetSingleCountryQuery : Country, IRequest<Country>
    {
    }
}
