namespace SafakBankApi.Models
{
    public class BaseAccount
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string? Currency { get; set; } = "TRY";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public int UserId { get; set; }
        public required User User { get; set; }
    }
}