using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Wallet.Entities
{
    public class CardType : BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
