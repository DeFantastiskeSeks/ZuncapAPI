using Microsoft.EntityFrameworkCore;
using ZuncapAPI.Models;

namespace ZuncapAPI.Context
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt) { }

        public DbSet<User> Users { get; set; }
    }
}
