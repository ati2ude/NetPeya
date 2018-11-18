using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Wallet.Entities
{
    public class Country
    {
        public int? ID { get; set; }
        public int DefaultCurrency { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
