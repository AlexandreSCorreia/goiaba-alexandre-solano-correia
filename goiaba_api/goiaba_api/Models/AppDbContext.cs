using Microsoft.EntityFrameworkCore;

namespace goiaba_api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<UserModel> Users { get; set; }

        
    }
}
