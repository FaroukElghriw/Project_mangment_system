using Microsoft.AspNetCore.Identity;

namespace Project_management_system.Models
{
    public class BaseModel:IdentityUser
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
