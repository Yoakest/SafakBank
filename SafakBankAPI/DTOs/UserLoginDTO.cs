using System.ComponentModel.DataAnnotations;

namespace SafakBankAPI.DTOs
{
    public class UserLoginDTO
    {
        [Required (ErrorMessage = "ERRUL01: Email giriniz.")]
        [EmailAddress(ErrorMessage = "ERRUL02: Geçerli bir e-posta adresi giriniz.")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "ERRUL03: Şifre giriniz.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "ERRUL04: Şifre en az 6 ve en fazla 100 karakter olmalıdır.")]
        public string? Password { get; set; }
    }
}
