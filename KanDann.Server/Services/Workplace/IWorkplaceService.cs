using KanDann.Server.Models.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KanDann.Server.Services.Workplace
{
    public interface IWorkplaceService
    {
        public Task Create(WorkPlaceDto workPlaceDto, string googleUserId);
    }
}
