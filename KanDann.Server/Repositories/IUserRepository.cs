using KanDann.Server.Models;
using KanDann.Server.Models.dtos;

namespace KanDann.Server.Repositories
{
    public interface IUserRepository
    {
        public Task SaveUser(UserClaimsDto userClaimsDto);
        public Task UpdateUser(UserClaimsDto userClaimsDto, User user);
    }
}
