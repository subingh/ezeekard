using EzeeKards.Service.Implementations;
using EzeeKards.Service.Interfaces;
using EzeeKards.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EzeeKards.Controllers
{
    public class ClientExtraInfoController : Controller
    {

        private readonly IClientExtraInfoService _clientExtraInfoService;
        public ClientExtraInfoController(IClientExtraInfoService clientExtraInfoService)
        {
            _clientExtraInfoService = clientExtraInfoService;
        }
        /// <summary>
        /// create client extra information of client
        /// </summary>
        /// <param name="request"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpPost("Create/Client/ExtraInfo")]
        public async Task<IActionResult> CreateClientExtraInfoAsync([FromForm] ExtraInfoClientRequest request, Guid clientId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _clientExtraInfoService.CreateClientExtraInfoAsync(request, clientId);
                if(result == null)
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
        /// update the client information as required
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("Update/Client/ExtraInfo")]
        public async Task<IActionResult> UpdateClientExtraInfoAsync(Guid Id, [FromForm] ExtraInfoClientRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _clientExtraInfoService.UpdateClientExtraInfoAsync(Id, request);

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
        /// delete client's extra information
        /// </summary>
        /// <param name="extraInfoId"></param>
        /// <returns></returns>
        [HttpDelete("Delete/Client/ExtraInfo")]
        public async Task<IActionResult> DeleteExtraInfoAsync([FromForm] Guid extraInfoId)
        {
            var result = await _clientExtraInfoService.DeleteExtraInfoAsync(extraInfoId);

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// getall information of client
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll/Clients/ExtraInfos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _clientExtraInfoService.GetAllAsync();

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }

        /// <summary>
        /// get client's extra information using get by id
        /// </summary>
        /// <param name="extraInfoId"></param>
        /// <returns></returns>
        [HttpGet("GetById/Client/ExtraInfo")]
        public async Task<IActionResult> GetByIdAsync(Guid extraInfoId)
        {
            var result = await _clientExtraInfoService.GetByIdAsync(extraInfoId);

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }
    }
}
