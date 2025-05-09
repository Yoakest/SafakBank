using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafakBankAPI.Data;
using SafakBankAPI.Helpers;
using SafakBankApi.Models;
using SafakBankAPI.DTOs;

namespace SafakBankAPI.Controllers.UserControllers
{
    [Route("api/user/login")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwtHelper;
        public UserLoginController(ApplicationDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        // POST: api/user/login Kullanıcı girişi  
        [HttpPost]
        public async Task<ActionResult<User>> Login(UserLoginDTO user)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser == null || !PasswordHelper.VerifyPassword(user.Password, existingUser.Password))
            {
                return NotFound(new { message = "Email veya şifre yanlış." });
            }
            else
            {
                var token = _jwtHelper.GenerateJwtToken(existingUser);
                return Ok(new
                {
                    message = "Giriş başarılı.",
                    token = token,
                });
            }
        }
    }
}
