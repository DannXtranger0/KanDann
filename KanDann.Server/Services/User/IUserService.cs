using KanDann.Server.Models.Dtos;

namespace KanDann.Server.Services.User
{
    public interface IUserService
    {
        Task<bool> UserIsNew(string email);
    }
}
