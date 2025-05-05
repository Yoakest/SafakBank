using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SafakBankApi.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "ERRCA01: Hesap adý zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ERRCA02: Hesap adý en az 3 ve en fazla 50 karakter olabilir.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "ERRCA03: Hesap numarasý zorunludur.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "ERRCA04: Hesap numarasý 10 karakter olmalýdýr.")]
        public string? AccountNumber { get; set; }

        [Precision(18, 2)]
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "TRY";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Kullanýcý ile iliþki
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}