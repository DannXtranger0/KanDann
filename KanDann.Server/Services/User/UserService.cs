
using KanDann.Server.Repositories.User;

namespace KanDann.Server.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> UserIsNew(string email)
        {
            return _userRepository.UserIsNew(email);
        }

    }
}
