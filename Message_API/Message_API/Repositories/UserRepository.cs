using Message_API.Data;
using Message_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Message_API.Repositories
{
    public interface IUserRepository
    {
        public bool update_profile(Users user);
        public bool login_user(string username, string password);
        public bool regist_user(string username, string password, string Nome);
        public bool save_image(IFormFile image);
    }

    public class UserRepository : IUserRepository
    {
        private readonly APIDbContext db;
        private readonly string dir_img_path = @"C:\Users\diogo\Desktop\img_teste";

        public UserRepository(APIDbContext _db)
        {
            db = _db;
        }

        public bool login_user(string username, string password)
        {
            var login = db.users.FirstOrDefault(l => l.username == username);
            if (login != null)
            {
                var _encryptcheck = new Encrypt();
                var teste = _encryptcheck.passwords_match(login.password, password);

                if (teste == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }

        public bool regist_user(string username, string password, string Nome)
        {
            var check_username = db.users.FirstOrDefault(l => l.username == username);
            if (check_username == null)
            {
                var _encryptpassword = new Encrypt();
                var _encryptedpassword = _encryptpassword.Encrypt_string(password);
                var new_user = new Users();
                new_user.username = username;
                new_user.password = _encryptedpassword;
                new_user.name = Nome;
                db.users.Add(new_user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool update_profile(Users user)
        {
            if(user != null)
            {
                db.users.Update(user);

                if(db.SaveChanges() != null)
                {
                    return true;
                }else 
                { 
                    return false; 
                }
            }
            else
            {
                return false;
            }
        }

        public bool save_image(IFormFile image, int user_id)
        {
            try
            {
                string imagePath = Path.Combine(dir_img_path, $"image_{user_id}");
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
} 
