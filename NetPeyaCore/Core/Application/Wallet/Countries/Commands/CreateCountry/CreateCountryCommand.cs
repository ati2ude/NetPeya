using MediatR;
using System;

namespace Core.Application.Wallet.Countries.Commands
{
    public class CreateCountryCommand : IRequest
    {
        public int ID { get; set; }
        public int DefaultCurrencyID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

