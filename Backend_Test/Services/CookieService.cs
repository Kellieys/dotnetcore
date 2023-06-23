using System;
using Backend_Test.Models;
using Backend_Test.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Test.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetPrimarySidClaim()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst("PrimarySid")?.Value;
        }

        public string GetNameClaim()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst("Name")?.Value;
        }
    }

    public interface ICookieService
    {
        string GetPrimarySidClaim();
        string GetNameClaim();
    }
}
