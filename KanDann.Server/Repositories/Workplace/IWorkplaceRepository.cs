using KanDann.Server.Models;
using KanDann.Server.Models.Dtos;

namespace KanDann.Server.Repositories.User
{
    public interface IWorkplaceRepository
    {
        public Task Create(WorkPlaceDto workPlaceDto, string userGoogleId);
    }
}
