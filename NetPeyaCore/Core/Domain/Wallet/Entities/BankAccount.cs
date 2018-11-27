using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Wallet.Entities
{
    public class BankAccount : BaseEntity
    {
        public int ID { get; set; }
        public bool IsDefault { get; set; }
        public int UserID { get; set; }
        public string Beneficiary { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string IBANumber { get; set; }
        public string SwiftCode { get; set; }
        public string Currency { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
