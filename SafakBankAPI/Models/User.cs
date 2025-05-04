using System.ComponentModel.DataAnnotations;

namespace SafakBankApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? NationalityId { get; set; }
        public string? JobTitle { get; set; }
        public int? Salary { get; set; }
        public string? EducationLevel { get; set; }
        public bool IsActive { get; set; } = true;

        // Bir kullan�c� birden fazla vadesiz hesaba sahip olabilir
        public ICollection<CheckingAccount> CheckingAccounts { get; set; } = new List<CheckingAccount>();
    }
}