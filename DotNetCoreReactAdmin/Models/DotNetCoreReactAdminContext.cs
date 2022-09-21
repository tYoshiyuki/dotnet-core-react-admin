using Microsoft.EntityFrameworkCore;

namespace DotNetCoreReactAdmin.Models
{
    public class DotNetCoreReactAdminContext : DbContext
    {
        public DotNetCoreReactAdminContext(DbContextOptions<DotNetCoreReactAdminContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
