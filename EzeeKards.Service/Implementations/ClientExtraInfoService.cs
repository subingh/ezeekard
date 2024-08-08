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
    public class ClientExtraInfoService : IClientExtraInfoService
    {
        public readonly ExtraInfoConverter _converter;
        private readonly ApplicationDbContext _dbContext;
        private readonly IErrorService _errorService;
        public ClientExtraInfoService(ExtraInfoConverter converter, ApplicationDbContext dbContext, IErrorService errorService)
        {
            _converter = converter;
            _dbContext = dbContext;
            _errorService = errorService;
        }
        public async Task<OperationResult<ExtraInfoClientResponse>> CreateClientExtraInfoAsync(ExtraInfoClientRequest request, Guid clientId)
        {
            var operation = new OperationResult<ExtraInfoClientResponse>();
            try
            {
                var clientExtraInfo = _converter.ClientToEntity(request);
                clientExtraInfo.ClientId = clientId;
                _dbContext.ClientExtraInfo.Add(clientExtraInfo);
                await _dbContext.SaveChangesAsync();
                operation.Result = _converter.ClientToModel(clientExtraInfo);
                operation.Status = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        public async Task<OperationResult<ExtraInfoClientResponse>> DeleteExtraInfoAsync(Guid extraInfoId)
        {
            var operation = new OperationResult<ExtraInfoClientResponse>();
            try
            {
                var clientExtraInfo = await _dbContext.ClientExtraInfo.FindAsync(extraInfoId);
                if (clientExtraInfo == null)
                {
                   
                    operation.Status = HttpStatusCode.NotFound;
                    operation.Exception = new Exception("Client not found.");
                    return operation;
                }
               
                clientExtraInfo.IsDeleted = !clientExtraInfo.IsDeleted;

                _dbContext.ClientExtraInfo.Update(clientExtraInfo);
                await _dbContext.SaveChangesAsync();

                var deletedClientDto = _converter.ClientToModel(clientExtraInfo);

                operation.Result = deletedClientDto;
                operation.Status = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {

                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        public async Task<OperationResult<IEnumerable<ExtraInfoClientResponse>>> GetAllAsync()
        {
            var operation = new OperationResult<IEnumerable<ExtraInfoClientResponse>>();
            try
            {
                var clientExtraInfo =  _dbContext.ClientExtraInfo.ToList();
                if (clientExtraInfo == null)
                {
                    operation.Exception = new Exception("Client ExtraInfo not found");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                operation.Result = clientExtraInfo.Select(_converter.ClientToModel);
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;

        }

        public async Task<OperationResult<ExtraInfoClientResponse>> GetByIdAsync(Guid extraInfoId)
        {
            var operation = new OperationResult<ExtraInfoClientResponse>();
            try
            {
                var clientExtraInfo = await _dbContext.ClientExtraInfo.FirstOrDefaultAsync(u => Guid.Equals(u.Id, extraInfoId));
                if (clientExtraInfo == null)
                {
                    operation.Exception = new Exception("Client ExtraInfo not found");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }

                operation.Result = _converter.ClientToModel(clientExtraInfo);
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        public async Task<OperationResult<ExtraInfoClientResponse>> UpdateClientExtraInfoAsync(Guid extraInfoId, ExtraInfoClientRequest request)
        {
            var operation = new OperationResult<ExtraInfoClientResponse>();
            try
            {
                var clientExtraInfo = await _dbContext.ClientExtraInfo.FirstOrDefaultAsync(u => Guid.Equals(u.Id, extraInfoId));
                if (clientExtraInfo == null)
                {
                    operation.Exception = new Exception("Client ExtraInfo not found");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                _converter.ClientToDomain(clientExtraInfo, request);
                _dbContext.Update(clientExtraInfo);
                var result = await _dbContext.SaveChangesAsync();
                if (result <= 0)
                {
                    operation.Exception = new Exception($"Client with {extraInfoId} id is not updated in the database ");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                var updatedCompanyDto = _converter.ClientToModel(clientExtraInfo);
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
