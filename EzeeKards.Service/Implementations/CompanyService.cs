using EzeeKard.Service.Converters;
using EzeeKard.Service.Implementations;
using EzeeKard.Service.Interfaces;
using EzeeKards.Common.Helpers;
using EzeeKards.Data.Database;
using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Converter;
using EzeeKards.Service.Interfaces;
using EzeeKards.Service.Models.Users;
using LogBook.Common.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EzeeKards.Service.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyConverter _converter;
        private readonly ApplicationDbContext _dbContext;
        private readonly IErrorService _errorService;
        public CompanyService(CompanyConverter converter, ApplicationDbContext dbContext, IErrorService errorService)
        {
            _converter = converter;
            _dbContext = dbContext;
            _errorService = errorService;

        }
        /// <summary>
        /// Create Company for Client
        /// </summary>
        /// <param name="ClientId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OperationResult<CompanyResponse>> CreateCompanyAsync(CompanyRequest request, Guid clientId)
        {
            var operation = new OperationResult<CompanyResponse>();
            try
            {     
                 var company = _converter.ToEntity(request);
                 company.ClientId = clientId;

                //check if requested image is null or not
                if (request.CompanyLogo != null)
                {
                    // Define the folder path and ensure it exists
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                    //Check if directory exist or not, if not create directory
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Generate a unique file name for the image
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.CompanyLogo.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    // Save the image file to the folder
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.CompanyLogo.CopyToAsync(stream);
                    }

                    // Set the ImageUrl property to the relative path
                    company.CompanyLogo = $"/images/{fileName}";
                }
                _dbContext.Company.Add(company);
                 await _dbContext.SaveChangesAsync();
                 operation.Result = _converter.ToModel(company);
                 operation.Status = HttpStatusCode.OK;
                
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            // Convert the updated/added company entity to a CompanyResponse
            return operation;
        }

        /// <summary>
        /// Update Comapany Data
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OperationResult<CompanyResponse>> UpdateCompanyAsync(Guid companyId, CompanyRequest request)
        {
            var operation = new OperationResult<CompanyResponse>();
            try
            {
                var companydata = await _dbContext.Company.FirstOrDefaultAsync(u => Guid.Equals(u.CompanyId, companyId));
                if (companydata == null)
                {
                    operation.Exception = new Exception("Company not found");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                _converter.ToDomain(companydata, request);

                //check if requested image is null or not
                if (request.CompanyLogo != null)
                {
                    // Define the folder path and ensure it exists
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "logo");

                    //Check if directory exist or not, if not create directory
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Generate a unique file name for the image
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.CompanyLogo.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    // Save the image file to the folder
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.CompanyLogo.CopyToAsync(stream);
                    }

                    // Set the ImageUrl property to the relative path
                    companydata.CompanyLogo = $"/images/companylogo/{fileName}";
                }

                _dbContext.Update(companydata);
                var result = await _dbContext.SaveChangesAsync();
                if (result <= 0)
                {
                    operation.Exception = new Exception($"Company with {companyId} id is not updated in the database ");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                var updatedCompanyDto = _converter.ToModel(companydata);
                operation.Result = updatedCompanyDto;
                operation.Status = HttpStatusCode.OK;

                // Convert the updated/added company entity to a CompanyResponse
                return operation;

            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }
        public async Task<OperationResult<CompanyResponse>> DeleteCompanyAsync(Guid companyId)
        {
            var operation = new OperationResult<CompanyResponse>();
            try
            {
                // Retrieve the client from the database
                var company = await _dbContext.Company.FirstOrDefaultAsync(u => Guid.Equals(u.CompanyId, companyId));
                if (company == null)
                {
                    operation.Status = HttpStatusCode.NotFound;
                    operation.Exception = new Exception("Company not found.");
                    return operation;
                }
                //Change the value of IsDeleted (flag to true)
                company.IsDeleted = !company.IsDeleted;

                _dbContext.Company.Update(company);
                await _dbContext.SaveChangesAsync();

                var deletedClientDto = _converter.ToModel(company);

                operation.Result = deletedClientDto;
                operation.Status = HttpStatusCode.OK;
            }
            
            catch (Exception ex)
            {

                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        /// <summary>
        /// company details get by id
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<OperationResult<CompanyResponse>> GetByIdAsync(Guid companyId)
        {
            var operation = new OperationResult<CompanyResponse>();
            try
            {
                var companydata = await _dbContext.Company.FirstOrDefaultAsync(u => Guid.Equals(u.CompanyId, companyId));
                if (companydata == null)
                {
                    operation.Exception = new Exception("Company not found");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }

                operation.Result = _converter.ToModel(companydata);
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        public async Task<OperationResult<IEnumerable<CompanyResponse>>> GetAllAsync()
        {
            var operation = new OperationResult<IEnumerable<CompanyResponse>>();
            try
            {
                var companies = await _dbContext.Company.ToListAsync();
                if (companies == null)
                {
                    operation.Exception = new Exception("No clients present.");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                operation.Result = companies.Select(_converter.ToModel);
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }
    }
}
