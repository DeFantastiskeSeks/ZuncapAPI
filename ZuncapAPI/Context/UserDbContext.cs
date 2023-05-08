using Microsoft.EntityFrameworkCore;

namespace ZuncapAPI.Context
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
