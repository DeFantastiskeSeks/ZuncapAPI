using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZuncapAPI.Models;
using ZuncapAPI.Repository;

namespace ZuncapAPI.Controllers
{
    public class UsersController : ControllerBase
    {
        public IUserRepository _repo;
        public UsersController(IUserRepository repo)

        {
            _repo = repo;
        }

        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<User> Get()

        {
            List<User> result = _repo.GetAll();

            if (result.Count < 1 )
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

            try {
                if (User == null)
                {
                    throw new ArgumentNullException("Null fejl");
                }
                User NewUser = _repo.Create(User);

                return Created($"api/User/add/{NewUser.UserId}", NewUser);



            } catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
                

            } catch(ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) 
            {

                return BadRequest(ex.Message);
            }
            
          
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> Delete(int userId) 
        { 
      
            User user = _repo.Delete(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
