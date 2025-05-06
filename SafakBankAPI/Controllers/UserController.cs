using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafakBankAPI.Data;
using SafakBankApi.Models;
using SafakBankAPI.Helpers;

namespace SafakBankAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly GenerateUserCode _generateUserCode;
        private readonly EmailChecker _emailChecker;

        public UserController(ApplicationDbContext context,
           GenerateUserCode generateUserCode,
           EmailChecker emailChecker)
        {
            _context = context;
            _generateUserCode = generateUserCode;
            _emailChecker = emailChecker;
        }

        // GET: api/user Kullanıcıları listele
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/user/5 Kullanıcıyı ID ile getir
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/user Kullanıcı ekle
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            string hasedPass = PasswordHelper.HashPassword(user.Password);
            user.Password = hasedPass;

            bool isEmailUnique = await _emailChecker.IsEmailUnique(user.Email);

            if (!isEmailUnique)
            {
                return BadRequest("ERRU16: Bu e-posta adresi zaten kayıtlı.");
            }



            user.UserCode = await _generateUserCode.Generate();

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new { user.Name, user.Surname });

        }

        // PUT: api/user/5 Kullanıcı güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/user/5 Kullanıcı sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        // GET: api/user/:id/data Kullanıcı verilerini getir
        [HttpGet("{id}/data")]
        public async Task<IActionResult> GetUserData(int id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Address = u.Address,
                    JobTitle = u.JobTitle,
                    Salary = u.Salary,
                    EducationLevel = u.EducationLevel
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
