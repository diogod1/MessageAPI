using Message_API.Data;
using Message_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Message_API.Repositories
{
    public interface IUserRepository
    {
        public bool update_profile(Users user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly APIDbContext db;

        public UserRepository(APIDbContext _db)
        {
            db = _db;
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
    }
} 
