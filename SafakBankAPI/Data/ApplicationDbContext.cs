using Microsoft.EntityFrameworkCore;
using SafakBankApi.Models;

namespace SafakBankAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }

    }
}
