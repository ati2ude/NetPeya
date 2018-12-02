using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Domain.Wallet.Entities
{
    public class BankAccount : BaseEntity
    {
        public int ID { get; set; }
        public bool IsDefault { get; set; }

        [Required]
        public int UserID { get; set; }
        [Required]
        public string Beneficiary { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string IBANumber { get; set; }
        [Required]
        public string SwiftCode { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
