using Message_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Message_API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Message> messages { get; set; }
    }
}
