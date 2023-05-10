using Microsoft.EntityFrameworkCore;
using ZuncapAPI.Models;

namespace ZuncapAPI.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }



       


            // How to initialise dboptions with connection string
        // var opt = new DbContextOptionsBuilder<UserDbContext>();
        // opt.UseSqlServer(Secrets.Secrets.ConnectionString);

        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Secrets.Secrets.ConnectionString);
        }




        public DbSet<User> Users { get; set; }
    }
}
 