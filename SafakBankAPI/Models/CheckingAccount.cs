using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SafakBankApi.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "ERRCA01: Hesap ad� zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "ERRCA02: Hesap ad� en az 3 ve en fazla 50 karakter olabilir.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "ERRCA03: Hesap numaras� zorunludur.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "ERRCA04: Hesap numaras� 10 karakter olmal�d�r.")]
        public string? AccountNumber { get; set; }

        [Precision(18, 2)]
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "TRY";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Kullan�c� ile ili�ki
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}