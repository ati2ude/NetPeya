using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Wallet.Entities
{
    public class Country : BaseEntity
    {
        public int ID { get; set; }

        [Required]
        public int? DefaultCurrencyID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 2)]
        public string Code { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 1)]
        public string PhoneCode { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
