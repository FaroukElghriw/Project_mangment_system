using Microsoft.EntityFrameworkCore;
using Project_management_system.Models;

namespace Project_management_system.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options):base(options) { }
        
            
        
        public DbSet<User> Users { get; set; }
    }
}
