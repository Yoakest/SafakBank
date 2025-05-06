using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SafakBankApi.Models
{
    [Index(nameof(UserCode), IsUnique = true, Name = "IX_User_UserCode")]
    [Index(nameof(Email), IsUnique = true, Name = "IX_User_Email")]
    [Index(nameof(PhoneNumber), IsUnique = true, Name = "IX_User_PhoneNumber")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ERRU01: Ad alanı zorunludur.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "ERRU02: Ad en az 2 ve en fazla 50 karakter olabilir.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "ERRU03: Soyad alanı zorunludur.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "ERRU04: Soyad en az 2 ve en fazla 50 karakter olabilir.")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "ERRU05: E-posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "ERRU06: Geçerli bir e-posta adresi giriniz.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "ERRU07: Şifre alanı zorunludur.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "ERRU08: Şifre en az 6 ve en fazla 100 karakter olmalıdır.")]
        public string? Password { get; set; }

        [Phone(ErrorMessage = "ERRU09: Geçerli bir telefon numarası giriniz.")]
        public string? PhoneNumber { get; set; }

        public string? UserCode { get; set; }

        [StringLength(200, ErrorMessage = "ERRU10: Adres en fazla 200 karakter olabilir.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "ERRU11: Doğum tarihi zorunludur.")]
        [DataType(DataType.Date, ErrorMessage = "ERRU12: Geçerli bir tarih giriniz.")]
        [Range(typeof(DateTime), "1896-1-1", "2025-12-31", ErrorMessage = "ERRU15: Doğum tarihi 1896 ile 2025 arasında olmalıdır.")]

        public DateTime? DateOfBirth { get; set; }

        [StringLength(11, ErrorMessage = "ERRU13: TC Kimlik Numarası 11 karakter olmalıdır.")]
        public string? NationalityId { get; set; }
        public string? JobTitle { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "ERRU14: Maaş negatif olamaz.")]
        public int? Salary { get; set; }
        public string? EducationLevel { get; set; }
        public bool IsActive { get; set; } = true;

        // Bir kullanıcı birden fazla vadesiz hesaba sahip olabilir
        public ICollection<CheckingAccount> CheckingAccounts { get; set; } = new List<CheckingAccount>();
    }
}