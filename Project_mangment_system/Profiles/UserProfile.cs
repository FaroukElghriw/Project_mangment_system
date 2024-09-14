using AutoMapper;
using Project_management_system.DTO.UserDTOs;
using Project_management_system.Models;

namespace Project_management_system.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
