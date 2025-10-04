using KanDann.Server.Models;
using KanDann.Server.Models.Context;
using KanDann.Server.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace KanDann.Server.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        public UserRepository(MyDbContext context)
        {
            _context = context;
        }


        public async Task SaveUser(UserClaimsDto userClaimsDto)
        {
            var user = new Models.User
            {
                Email = userClaimsDto.Email,
                Name = userClaimsDto.Name,
                GoogleUserId = userClaimsDto.GoogleId,
                AvatarUrl = userClaimsDto.Picture,
                CreatedAt = DateTime.UtcNow,
                LastLogin = DateTime.UtcNow
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(UserClaimsDto userClaimsDto, Models.User user)
        {
            user.LastLogin = DateTime.UtcNow;
            user.Name = userClaimsDto.Name ?? user.Name;
            user.AvatarUrl = userClaimsDto.Picture ?? user.AvatarUrl;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserIsNew(string email)
        {
            //obtener el id del usuario
            int userId = await _context.Users.Where(x=>x.Email==email).Select(x=>x.Id).FirstOrDefaultAsync();
            //hay algún workspace creado con el id del usuario autenticado?
            return !_context.WorkPlaces.Any(x=>x.UserId==userId);
        }
    }
}
