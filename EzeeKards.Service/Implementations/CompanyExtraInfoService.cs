using Azure.Core;
using EzeeKard.Data.Entities.Dtos;
using EzeeKard.Service.Interfaces;
using EzeeKards.Data.Database;
using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Converter;
using EzeeKards.Service.Implementation;
using EzeeKards.Service.Interfaces;
using EzeeKards.Service.Models.Users;
using LogBook.Common.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EzeeKards.Service.Implementations
{
    public class CompanyExtraInfoService : ICompanyExtraInfoService
    {
        public readonly ExtraInfoConverter _converter;
        private readonly ApplicationDbContext _dbContext;
        private readonly IErrorService _errorService;
        public CompanyExtraInfoService(ExtraInfoConverter converter, ApplicationDbContext dbContext, IErrorService errorService)
        {
            _converter = converter;
            _dbContext = dbContext;
            _errorService = errorService;
        }
        public async Task<OperationResult<ExtraInfoCompanyResponse>> CreateCompanyExtraInfoAsync(ExtraInfoCompanyRequest request, Guid companyId)
        {
            var operation = new OperationResult<ExtraInfoCompanyResponse>();
            try
            {
                var companyExtraInfo = _converter.CompanyToEntity(request);
                companyExtraInfo.CompanyId = companyId;
                _dbContext.CompanyExtraInfo.Add(companyExtraInfo);
                await _dbContext.SaveChangesAsync();
                operation.Result = _converter.CompanyToModel(companyExtraInfo);
                operation.Status = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        public async Task<OperationResult<ExtraInfoCompanyResponse>> DeleteExtraInfoAsync(Guid extraInfoId)
        {
            var operation = new OperationResult<ExtraInfoCompanyResponse>();
            try
            {
                var companyExtraInfo = await _dbContext.CompanyExtraInfo.FindAsync(extraInfoId);
                if (companyExtraInfo == null)
                {
                   
                    operation.Status = HttpStatusCode.NotFound;
                    operation.Exception = new Exception("Company not found.");
                    return operation;
                }
               
                companyExtraInfo.IsDeleted = !companyExtraInfo.IsDeleted;

                _dbContext.CompanyExtraInfo.Update(companyExtraInfo);
                await _dbContext.SaveChangesAsync();

                var deletedCompanyDto = _converter.CompanyToModel(companyExtraInfo);

                operation.Result = deletedCompanyDto;
                operation.Status = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {

                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        public async Task<OperationResult<IEnumerable<ExtraInfoCompanyResponse>>> GetAllAsync()
        {
            var operation = new OperationResult<IEnumerable<ExtraInfoCompanyResponse>>();
            try
            {
                var companyExtraInfo =  _dbContext.CompanyExtraInfo.ToList();
                if (companyExtraInfo == null)
                {
                    operation.Exception = new Exception("Company ExtraInfo not found");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                operation.Result = companyExtraInfo.Select(_converter.CompanyToModel);
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;

        }

        public async Task<OperationResult<ExtraInfoCompanyResponse>> GetByIdAsync(Guid extraInfoId)
        {
            var operation = new OperationResult<ExtraInfoCompanyResponse>();
            try
            {
                var companyExtraInfo = await _dbContext.CompanyExtraInfo.FirstOrDefaultAsync(u => Guid.Equals(u.Id, extraInfoId));
                if (companyExtraInfo == null)
                {
                    operation.Exception = new Exception("Company ExtraInfo not found");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }

                operation.Result = _converter.CompanyToModel(companyExtraInfo);
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        public async Task<OperationResult<ExtraInfoCompanyResponse>> UpdateCompanyExtraInfoAsync(Guid extraInfoId, ExtraInfoCompanyRequest request)
        {
            var operation = new OperationResult<ExtraInfoCompanyResponse>();
            try
            {
                var companyExtraInfo = await _dbContext.CompanyExtraInfo.FirstOrDefaultAsync(u => Guid.Equals(u.Id, extraInfoId));
                if (companyExtraInfo == null)
                {
                    operation.Exception = new Exception("Company ExtraInfo not found");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                _converter.CompanyToDomain(companyExtraInfo, request);
                _dbContext.Update(companyExtraInfo);
                var result = await _dbContext.SaveChangesAsync();
                if (result <= 0)
                {
                    operation.Exception = new Exception($"Company with {extraInfoId} id is not updated in the database ");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                var updatedCompanyDto = _converter.CompanyToModel(companyExtraInfo);
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
    }
}
