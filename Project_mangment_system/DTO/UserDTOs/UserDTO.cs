using Project_management_system.Models;
using System.ComponentModel.DataAnnotations;

namespace Project_management_system.DTO.UserDTOs
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageURL { get; set; }
        public string Country { get; set; }
        public bool IsVerified { get; set; }
        public  string DisplayName { get; set; }
        public string Token { get; set; }


    }
}
