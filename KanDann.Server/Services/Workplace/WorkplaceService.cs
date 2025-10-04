using Azure.Core;
using KanDann.Server.Controllers;
using KanDann.Server.Models;
using KanDann.Server.Models.Context;
using KanDann.Server.Models.Dtos;
using KanDann.Server.Repositories.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace KanDann.Server.Services.Workplace
{
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _workplaceRepository;
        public WorkplaceService( IWorkplaceRepository workplaceRepository)
        {
            _workplaceRepository = workplaceRepository;
        }

        public async Task Create(WorkPlaceDto workPlaceDto, string googleUserId)
        {
            await _workplaceRepository.Create(workPlaceDto, googleUserId);
        }
    }
}
