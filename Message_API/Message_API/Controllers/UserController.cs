using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Message_API.Models;
using Message_API.Repositories;
using Message_API.Data;

namespace Message_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repos;
        private readonly APIDbContext db;

        public UserController(APIDbContext _db, IUserRepository _repos)
        {
            db = _db;
            repos = _repos;
        }

        [HttpPost("login-user")]
        public ActionResult Login(string username, string password)
        {
            var login = repos.login_user(username, password);

            if (login == true)
            {
                // Login successful
                return Ok();
            }
            else
            {
                // Login failed
                return BadRequest();
            }
        }      

        [HttpPut("update-user")]
        public IActionResult UpdateUser(int id, RequestUserUpdate requestUser)
        {
            var userCheck = db.users.Find(id);
            if (userCheck == null)
            {
                return NotFound();
            }
            else
            {
                userCheck.bio= requestUser.bio;
                userCheck.name= requestUser.name;
                userCheck.photo_path= requestUser.photo_path;
                userCheck.status= requestUser.status;
                db.SaveChanges();
                return Ok();
            }
        }

    }
}
