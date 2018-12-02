using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Wallet.Entities
{
    public class BaseEntity
    {
        [NotMapped]
        public int statusCode { get; set; }
    }
}
