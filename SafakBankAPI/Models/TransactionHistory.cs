using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafakBankApi.Models
{
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; } // Benzersiz iþlem kimliði

        public DateTime TransactionDate { get; set; } = DateTime.Now; // Ýþlem tarihi

        public string? TransactionName { get; set; } // Ýþlem adý (örneðin, "Para Yatýrma", "Para Çekme", "Para Gönderme", "Para Gelmesi")


        public string? Description { get; set; } // Ýþlem açýklamasý

        public decimal Amount { get; set; } // Ýþlem tutarý

        // CheckingAccount ile iliþki
        public int CheckingAccountId { get; set; }
        public CheckingAccount? CheckingAccount { get; set; }

        // User ile iliþki
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

