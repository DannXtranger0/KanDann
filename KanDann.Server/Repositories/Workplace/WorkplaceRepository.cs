using KanDann.Server.Models;
using KanDann.Server.Models.Context;
using KanDann.Server.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace KanDann.Server.Repositories.User
{
    public class WorkplaceRepository : IWorkplaceRepository
    {
        private readonly MyDbContext _context;
        public WorkplaceRepository(MyDbContext context)
        {
            _context = context;
        }

    

        public async Task Create(WorkPlaceDto workPlaceDto, string userGoogleId)
        {
            var userId = await _context.Users.
                Where(x => x.GoogleUserId == userGoogleId).
                Select(x => x.Id).
                FirstOrDefaultAsync();

            var workplace = new WorkPlace
            {
                Name = workPlaceDto.Workplace,
                UserId = userId
            };

            _context.WorkPlaces.Add(workplace);
            await _context.SaveChangesAsync();
        }
    }
}
