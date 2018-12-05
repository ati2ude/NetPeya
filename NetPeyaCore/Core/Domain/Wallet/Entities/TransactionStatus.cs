using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Wallet.Entities
{
    public class TransactionStatus : BaseEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
