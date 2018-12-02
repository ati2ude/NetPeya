using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Wallet.Entities
{
    public class Recipient
    {
        public int ID { get; set; }

        [Required]
        public int? UserID { get; set; }

        [Required]
        [StringLength(60, MinimumLength =3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [StringLength(20, MinimumLength = 9)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [NotMapped]
        public int statusCode { get; set; }
    }
}
