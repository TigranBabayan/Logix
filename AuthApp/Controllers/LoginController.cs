using AuthApp.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private static string _conectionString = "";
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            _conectionString = _configuration.GetConnectionString("DefaultConnection");
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserLogin userLogin)
        {

            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.FirstName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Surname,user.LastName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.StreetAddress,user.Address),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                new Claim(ClaimTypes.DateOfBirth,user.DateOfBirth.ToString()),
            };

            var token = new JwtSecurityToken(claims:claims, expires: DateTime.Now.AddMinutes(15), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(UserLogin userLogin)
        {
            var user = new UserModel();
            if (userLogin != null)
            {
                using (IDbConnection db = new SqlConnection(_conectionString))
                {
                    string query = "SELECT * FROM Users WHERE Email = @Email and Password = @Password";
                    var parameters = new { Email = userLogin.Email, Password = HashPasword(userLogin.Password) };
                    return db.QueryFirstOrDefault<UserModel>(query, parameters);
                }
            }
            return null;
        }

        string HashPasword(string password)
        {
            string ret = "";
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.Unicode.GetBytes(password);
            bs = x.ComputeHash(bs);
            ret = "0x" + BitConverter.ToString(bs).Replace("-", "");
            return ret;
        }



    }
}
