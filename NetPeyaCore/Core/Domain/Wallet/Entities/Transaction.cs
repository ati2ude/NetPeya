using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Wallet.Entities
{
    public class Transaction : BaseEntity
    {
        public int ID { get; set; }
        [Required]
        public int? UserID { get; set; }
        [Required]
        public int? TransactionTypeID { get; set; }
        [Required]
        public int? PaymentMethodID { get; set; }
        [Required]
        public int? TransactionStatusID { get; set; }
        [Required]
        public decimal AmountBeforeCharges { get; set; }
        [Required]
        public decimal Charges { get; set; }
        [Required]
        public decimal AmountAfterCharges { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
