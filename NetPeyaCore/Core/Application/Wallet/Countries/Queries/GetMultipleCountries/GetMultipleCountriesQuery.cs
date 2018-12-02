using Core.Domain.Wallet.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wallet.Countries.Queries.GetAllCountries
{
    public class GetMultipleCountriesQuery : IRequest<List<Country>>
    {
    }
}
