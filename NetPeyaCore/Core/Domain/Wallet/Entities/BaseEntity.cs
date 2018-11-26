using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Domain.Wallet.Entities
{
    public class BaseEntity
    {
        [NotMapped]
        public EntityState entityState { get; set; }
    }
}
