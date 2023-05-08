using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZuncapAPI.Repository;

namespace ZuncapAPI.Controllers
{
    public class UsersController : Controller
    {
        public UserRepository _repo  { get; set; }
        public UsersController(UserRepository repo) 
        
        { 
         _repo = repo;
        }

        [HttpPost]
        [ProducesErrorResponseType(StatusCodes.Status201Created)]
        [ProducesErrorResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(StatusCodes.Status404NotFound)]


    }
}
