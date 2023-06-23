using System;
using Backend_Test.Context;
using Backend_Test.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Backend_Test.Services
{
    public class AdminRequirement : IAuthorizationRequirement
    {
    }
}
