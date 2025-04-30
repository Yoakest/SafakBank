using User = SafakBankApi.Models.User;

namespace SafakBankApi.Models
{
    public class CheckingAccount : BaseAccount
    {
        public decimal OverdraftLimit { get; set; }
        public decimal InterestRate { get; set; }
    }
}