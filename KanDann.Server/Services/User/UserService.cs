
using KanDann.Server.Models.Dtos;
using KanDann.Server.Repositories.User;
using Microsoft.AspNetCore.Mvc;

namespace KanDann.Server.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> UserIsNew(string email)
        {
            return await _userRepository.UserIsNew(email);
        }

    }
}
