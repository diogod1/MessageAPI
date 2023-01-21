using Message_API.Data;
using Message_API.Models;
using Message_API.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Search")]
        public IActionResult Search(string username)
        {
            var search = repos.search(username);
            if (search == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(search);
            }
        }

        [HttpPost("Login")]
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

        [HttpPost("Register")]
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

        [HttpPost("Save-Image")]
        public IActionResult SaveImage(IFormFile image, int user_id)
        {
            var userCheck = db.users.Find(user_id);
            if (userCheck == null)
            {
                return NotFound("User not found");
            }
            else
            {
                if (image != null)
                {
                    var save_img = repos.save_image(image, user_id);
                    return Ok(save_img);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateUser(int id, RequestUserUpdate requestUser)
        {
            var userCheck = db.users.Find(id);
            if (userCheck == null)
            {
                return NotFound();
            }
            else
            {
                userCheck.bio = requestUser.bio;
                userCheck.name = requestUser.name;
                userCheck.photo_path = requestUser.photo_path;
                userCheck.status = requestUser.status;
                db.SaveChanges();
                return Ok();
            }
        }

    }
}
