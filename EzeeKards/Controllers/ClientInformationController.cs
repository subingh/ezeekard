using EzeeKard.Service.Implementations;
using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Interfaces;
using EzeeKards.Service.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EzeeKards.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class ClientInformationController : ControllerBase
    {
        private readonly IClientInformationService _clientInformationService;
        public ClientInformationController(IClientInformationService clientInformationService)
        {
            _clientInformationService = clientInformationService;
        }

        [HttpGet("Getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _clientInformationService.GetAllAsync();

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }

            return Ok(result.Result);
        }

        [HttpGet("GetbyId")]
        public async Task<IActionResult> GetByIdAsync(Guid clientId)
        {
            var result = await _clientInformationService.GetByIdAsync(clientId);

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }
    }
}
