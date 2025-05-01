namespace SafakBankApi.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AccountNumber { get; set; }
        public decimal Balance { get; set; } = 0;
        public string Currency { get; set; } = "TRY";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Kullanýcý ile iliþki
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}