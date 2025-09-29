using KanDann.Server.Models;
using KanDann.Server.Models.Dtos;

namespace KanDann.Server.Repositories.User
{
    public interface IUserRepository
    {
        public Task SaveUser(UserClaimsDto userClaimsDto);
        public Task UpdateUser(UserClaimsDto userClaimsDto, Models.User user);
        public Task<bool> UserIsNew(string email);
    }
}
