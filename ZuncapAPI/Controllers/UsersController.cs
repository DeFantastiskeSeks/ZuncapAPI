using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZuncapAPI.Context;
using ZuncapAPI.Models;
using ZuncapAPI.Repository;

namespace ZuncapAPI.Controllers
{
    [Route("api/[controller]")]
    //URI: api/pokemons
    [ApiController]

    public class UsersController : ControllerBase
    {
        public IUserRepository _repo;
        private readonly UserDbContext _dbContext;
        public IConfiguration _configuration;
        public UsersController(IUserRepository repo, IConfiguration configuration, UserDbContext dbContext)

        {
            _repo = repo;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet("home")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<User> Get()
        {
            List<User> result = _repo.GetAll();

            if (result.Count < 1)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> POST([FromBody] User User)
        {

            try 
            {
                if (User == null)
                {
                    throw new ArgumentNullException("Null fejl");
                }
                User NewUser = _repo.Create(User);

                return Created($"api/User/add/{NewUser.UserId}", NewUser);
            } 
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            } 
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("exposure")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> POSTExpo(float uv, [FromBody] User user)
        {
            try
            {
                User exsistingUser = _repo.GetByName(user.Name!);
                exsistingUser.UVExpo = uv;
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> Delete([FromBody] int userId)
        {

            User user = _repo.Delete(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] User request)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Name == request.Name);
            if (existingUser != null)
            {
                return BadRequest("Username already exists");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var newUser = new User
            {
                Name = request.Name,
                Password = passwordHash
            };

            _repo.Create(newUser);
            return Ok(newUser);
        }



        [HttpPost("login")]
        public ActionResult<User> login([FromBody] User request)
        {
            var users = _dbContext.Users.FirstOrDefault(x => x.Name == request.Name);
            
               if(users == null)
            {
                return BadRequest("User Not Found");
            }
            
            if (!BCrypt.Net.BCrypt.Verify(request.Password, users.Password))
            {
                return BadRequest("wrong password");
            }

            string token = CreateToken(users);


            return Ok(token);

        }
        [ProducesResponseType(StatusCodes.Status308PermanentRedirect)]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Redirect("home");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        private string CreateToken(User user)
        {
          
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name!)
            };
        
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(3),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


    }
}
