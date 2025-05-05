namespace SafakBankAPI.Models
{
    public class UserHistory
    {
        public int Id { get; set; }
        
        public string? ActionName { get; set; }
        public string? Description { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.Now;

    }
}
