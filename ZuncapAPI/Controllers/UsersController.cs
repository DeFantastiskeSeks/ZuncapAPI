using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZuncapAPI.Models;
using ZuncapAPI.Repository;

namespace ZuncapAPI.Controllers
{
    public class UsersController : Controller
    {
        public UserRepository _repo { get; set; }
        public UsersController(UserRepository repo)

        {
            _repo = repo;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> POST([FromBody] User User)
        {

            try {

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


    }
}
