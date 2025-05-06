using Microsoft.EntityFrameworkCore;
using SafakBankAPI.Data;

namespace SafakBankAPI.Helpers
{
    public class EmailChecker
    {
        private readonly ApplicationDbContext _context;
        public EmailChecker(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            return !await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
