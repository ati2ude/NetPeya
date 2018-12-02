using System;
using System.Linq;
using Core.Persistence.Wallet;
using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Wallet.Entities
{
    public class WalletAccount
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CurrencyID { get; set; }
        public int WalletAccountCategoryID { get; set; }
        public string WalletAccountCode { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static string generateWalletAccountCode(int userID)
        {
            // Get number of seconds since 24 hours ago - to make sure this is unique
            string secondsNow = decimal.Truncate(
                    (decimal)TimeSpan.FromTicks(DateTime.Now.Ticks - DateTime.Now.AddDays(-1).Ticks).TotalSeconds
                ).ToString();

            int realCharacterLength = (secondsNow + userID.ToString()).Length;

            /*
             * We need WalletAccountCode to be 16 characters so we check how many characters are short to make that,
             * then inject that exact number of zeros in the middle.
             */ 
            return userID.ToString() + "".PadRight(16 - realCharacterLength, '0') + secondsNow; 
        }
    }
}
