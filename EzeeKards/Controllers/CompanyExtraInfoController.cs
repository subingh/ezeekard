using EzeeKards.Service.Interfaces;
using EzeeKards.Service.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EzeeKards.Controllers
{
    public class CompanyExtraInfoController : Controller
    {
        private readonly ICompanyExtraInfoService _companyExtraInfoService;
        public CompanyExtraInfoController(ICompanyExtraInfoService companyExtraInfoService)
        {
            _companyExtraInfoService = companyExtraInfoService;
        }

        [HttpPost("Create/Company/ExtraInfo")]
        public async Task<IActionResult> CreateCompanyExtraInfoAsync([FromForm] ExtraInfoCompanyRequest request, Guid companyId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _companyExtraInfoService.CreateCompanyExtraInfoAsync(request, companyId);
                if (result == null)
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
        [HttpPut("Update/Company/ExtraInfo")]
        [Authorize]
        public async Task<IActionResult> UpdateCompanyExtraInfoAsync(Guid Id, [FromForm] ExtraInfoCompanyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _companyExtraInfoService.UpdateCompanyExtraInfoAsync(Id, request);

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

        [HttpDelete("Delete/Company/ExtraInfo")]
        [Authorize]
        public async Task<IActionResult> DeleteExtraInfoAsync([FromForm] Guid extraInfoId)
        {
            var result = await _companyExtraInfoService.DeleteExtraInfoAsync(extraInfoId);

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }

        [HttpGet("GetAll/Companys/ExtraInfos")]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _companyExtraInfoService.GetAllAsync();

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }


        [HttpGet("GetById/Company/ExtraInfo")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync(Guid extraInfoId)
        {
            var result = await _companyExtraInfoService.GetByIdAsync(extraInfoId);

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }
    }
}
