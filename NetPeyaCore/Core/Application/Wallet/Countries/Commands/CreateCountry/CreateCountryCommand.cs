using Core.Domain.Wallet.Entities;
using MediatR;

namespace Core.Application.Wallet.Countries.Commands
{
    public class CreateCountryCommand : IRequest
    {
        public int ID { get; set; }
        public int DefaultCurrency { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

