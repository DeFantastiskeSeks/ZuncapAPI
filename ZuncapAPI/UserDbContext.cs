using Microsoft.EntityFrameworkCore;

namespace ZuncapAPI
{
    public class UserDbContext:DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
