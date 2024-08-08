using EzeeKards.Service.Interfaces;
using EzeeKards.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EzeeKards.Controllers
{
    public class CompanyController : Controller
    {

        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("Create/Company")]
        public async Task<IActionResult> CreateCompanyAsync([FromForm] CompanyRequest request, Guid clientId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _companyService.CreateCompanyAsync(request, clientId);
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
        [HttpPut("Update/Company")]
        public async Task<IActionResult> UpdateCompany([FromForm] Guid Id, [FromForm] CompanyRequest companyRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _companyService.UpdateCompanyAsync(Id, companyRequest);

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

        [HttpDelete("Delete/Companies")]
        public async Task<IActionResult> DeleteCompanyAsync(Guid companyId)
        {
            var result = await _companyService.DeleteCompanyAsync(companyId);

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }

        [HttpGet("GetAll/Companies")]
        public async Task<IActionResult> GetAllCompanyAsync()
        {
            var result = await _companyService.GetAllAsync();

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }


        [HttpGet("GetById/company")]
        public async Task<IActionResult> GetByIdAsync(Guid companyId)
        {
            var result = await _companyService.GetByIdAsync(companyId);

            if (result.Status == HttpStatusCode.NotFound)
            {
                return NotFound(result.Exception?.Message);
            }
            return Ok(result.Result);
        }
    }
}
