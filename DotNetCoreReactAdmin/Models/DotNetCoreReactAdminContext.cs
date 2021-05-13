using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreReactAdmin.Models
{
    public class DotNetCoreReactAdminContext : DbContext
    {
        public DotNetCoreReactAdminContext(DbContextOptions<DotNetCoreReactAdminContext> options)
            : base(options)
        {
        }

        public DbSet<DotNetCoreReactAdmin.Models.User> User { get; set; }
    }
}
