using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafakBankApi.Models
{
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; } // Benzersiz i�lem kimli�i

        public DateTime TransactionDate { get; set; } = DateTime.Now; // ��lem tarihi

        public string? TransactionName { get; set; } // ��lem ad� (�rne�in, "Para Yat�rma", "Para �ekme", "Para G�nderme", "Para Gelmesi")


        public string? Description { get; set; } // ��lem a��klamas�

        public decimal Amount { get; set; } // ��lem tutar�

        // CheckingAccount ile ili�ki
        public int CheckingAccountId { get; set; }
        public CheckingAccount? CheckingAccount { get; set; }

        // User ile ili�ki
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

