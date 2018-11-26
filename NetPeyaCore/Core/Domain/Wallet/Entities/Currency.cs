using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Wallet.Entities
{
    public class Currency
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Code { get; set; }
        public bool AddOnRegistration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
