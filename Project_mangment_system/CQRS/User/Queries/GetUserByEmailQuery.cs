using MediatR;
using Project_management_system.Models;
using Microsoft.EntityFrameworkCore;
using Project_management_system.Repositories;
using Project_management_system.Exceptions;
using Project_management_system.Enums;

namespace Project_management_system.CQRS.User.Queries
{
    public record GetUserByEmailQuery(string email):IRequest<Models.User>
    {
    }
    public record GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, Models.User>
    {
        private IBaseRepository<Models.User> _userRepository;
        public GetUserByEmailHandler(IBaseRepository<Models.User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Models.User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user=await _userRepository.GetAll().FirstOrDefaultAsync(u=>u.Email==request.email);
            if (user==null)
            {
                throw new BusinessException(ErrorCode.UserEmailNotFound,"Can not find user with this email");
            }
            return user;
        }
    }
}
