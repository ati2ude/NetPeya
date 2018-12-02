using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Domain.Wallet.Entities
{
    public class CardType : BaseEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
