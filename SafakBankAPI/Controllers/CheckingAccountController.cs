using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafakBankApi.Models;
using SafakBankAPI.Data;

namespace SafakBankAPI.Controllers
{
    [Route("api/checking-account")]
    [ApiController]
    public class CheckingAccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CheckingAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/checking-account
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckingAccount>> GetCheckingAccount(int id)
        {
            var CheckingAccounts = await _context.CheckingAccounts.FindAsync(id);
            if (CheckingAccounts == null)
            {
                return NotFound();
            }
            return CheckingAccounts;
        }

        // POST: api/checking-account
        [HttpPost]
        public async Task<ActionResult<CheckingAccount>> PostCheckingAccount(CheckingAccount checkingAccount)
        {
            if (checkingAccount.Currency == null)
            {
                checkingAccount.Currency = "TRY";
            }
            if (checkingAccount.Name == null)
            {
                checkingAccount.Name = $"Vadesiz {checkingAccount.Currency} Hesabı";
            }

            var latestAccountNumber = await _context.CheckingAccounts
                .OrderByDescending(c => c.AccountNumber)
                .Select(c => c.AccountNumber)
                .FirstOrDefaultAsync();

            if (latestAccountNumber == null)
            {
                checkingAccount.AccountNumber = "TR991234500000000001234567";
            }else
            {
                var numericPart = long.Parse(latestAccountNumber.Substring(10)) + 1;
                checkingAccount.AccountNumber = latestAccountNumber.Substring(0, 10) + numericPart.ToString("D16");
            }

            _context.CheckingAccounts.Add(checkingAccount);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCheckingAccount), new { id = checkingAccount.Id }, checkingAccount);
        }
    }
}
