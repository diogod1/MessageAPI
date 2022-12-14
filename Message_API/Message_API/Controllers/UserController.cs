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
        public IActionResult Login(RequestUserLogin request)
        {
            var login = repos.login_user(request.username, request.password);

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

        [HttpPost("Regist-user")]
        public IActionResult Register(RequestUserRegister request)
        {
            var regist_user = repos.regist_user(request.username, request.password, request.name);
            if (regist_user == true)
            {
                return Ok();
            }
            else
            {
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
