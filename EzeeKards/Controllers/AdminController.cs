using EzeeKards.Service.Interfaces;
using EzeeKards.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;



namespace EzeeKards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("api/User/LogIn")]
        public string LogIn([FromForm] LoginRequest request)
        {
            var result =_adminService.LogIn(request);
            return result;
        }
    }
}
