using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Employee> Employees { get; set; }

    
    }
}
