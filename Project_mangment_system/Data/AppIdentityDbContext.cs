using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_management_system.Models;

namespace Project_management_system.Data
{
	public class AppIdentityDbContext:IdentityDbContext<User>
	{
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options) 
        {
            
        }
    }
}
