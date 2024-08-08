using EzeeKard.Service.Implementations;
using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EzeeKards.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        //Defining a private field for a service
        private readonly IClientService _clientService;

        //constructor to access the private field in the class
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="clientRequest"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateClientAsync([FromForm]ClientRequest clientRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _clientService.CreateClientAsync(clientRequest);

                if (result.Exception != null)
                {
                    return StatusCode((int)result.Status, result.Exception.Message);
                }

                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Update Client Details
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="clientRequest"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateClient(Guid Id, [FromForm] ClientRequest clientRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _clientService.UpdateClientAsync(Id, clientRequest);

                if (result.Status != HttpStatusCode.OK)
                {
                    return StatusCode((int)result.Status, result.Exception?.Message);
                }
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Soft delete the client
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteClientAsync(Guid clientId)
        {
            var result = await _clientService.DeleteClientAsync(clientId);

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// Gell all available clients
        /// </summary>
        /// <returns></returns>
        [HttpGet("Getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _clientService.GetAllAsync();

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }

            return Ok(result.Result);
        }

        /// <summary>
        /// Get client using get by id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("GetbyId")]
        public async Task<IActionResult> GetByIdAsync(Guid clientId)
        {
            var result = await _clientService.GetByIdAsync(clientId);

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }
    }
}
