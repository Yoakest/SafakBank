using Microsoft.EntityFrameworkCore;
using SafakBankAPI.Data;

namespace SafakBankAPI.Helpers
{
    public class GenerateUserCode
    {
        private readonly ApplicationDbContext _context;
        public GenerateUserCode(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Generate()
        {
            string userCode;
            bool exists;

            do
            {
                userCode = CreateUserCode();
                exists = await _context.Users.AnyAsync(u => u.UserCode == userCode);
            }
            while (exists);

            return userCode;
        }

        private static string CreateUserCode()
        {
            var random = new Random();
            var number = random.Next(1000000000, 2000000000); // 10 haneli bir sayı üretir
            return $"SB{number}";
        }
    }
}