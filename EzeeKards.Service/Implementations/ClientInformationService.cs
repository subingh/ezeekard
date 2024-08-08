using EzeeKard.Service.Converters;
using EzeeKard.Service.Interfaces;
using EzeeKards.Data.Database;
using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Converter;
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

namespace EzeeKards.Service.Implementations
{
    public class ClientInformationService : IClientInformationService
    {
        private readonly ClientInformationConverter _converter;
        private readonly ApplicationDbContext _dbContext;
        private readonly IErrorService _errorService;
        public ClientInformationService(ClientInformationConverter converter, ApplicationDbContext dbContext, IErrorService errorService)
        {
            _converter = converter;
            _dbContext = dbContext;
            _errorService = errorService;
        }

        public async Task<OperationResult<List<ClientDetails>>> GetAllAsync()
        {
            var operation = new OperationResult<List<ClientDetails>>();

            try
            {
                // Asynchronously fetch data from the database
                var clients = await _dbContext.Client.ToListAsync();
                var clientExtraInfoList = await _dbContext.ClientExtraInfo.ToListAsync();
                var companies = await _dbContext.Company.ToListAsync();
                var companyExtraInfoList = await _dbContext.CompanyExtraInfo.ToListAsync();

                // Convert data to domain model
                var clientDetails = _converter.ClientToDomain(clients, clientExtraInfoList, companies, companyExtraInfoList).ToList();

                operation.Result = clientDetails;
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
                operation.Status = HttpStatusCode.InternalServerError;
                operation.Exception = ex; // Ensure the exception is set for debugging/logging
            }

            return operation;
        }

        public async Task<OperationResult<List<ClientDetails>>> GetByIdAsync(Guid clientId)
        {
            var operation = new OperationResult<List<ClientDetails>>();

            try
            {
                // Fetch the client from the database
                var client = await _dbContext.Client.FirstOrDefaultAsync(u => u.ClientId == clientId);
                if (client == null)
                {
                    operation.Exception = new Exception("Client not found.");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }

                // Fetch all ClientExtraInfo records related to the client
                var clientExtraInfoList = await _dbContext.ClientExtraInfo
                    .Where(e => e.ClientId == clientId)
                    .ToListAsync();

                // Fetch all companies related to the client
                var companies = await _dbContext.Company
                    .Where(c => c.ClientId == clientId)
                    .ToListAsync();

                // Fetch all CompanyExtraInfo records related to the fetched companies
                var companyIds = companies.Select(c => c.CompanyId).ToList();
                var companyExtraInfoList = await _dbContext.CompanyExtraInfo
                    .Where(e => companyIds.Contains(e.CompanyId))
                    .ToListAsync();

                // Convert data to domain model
                var clientDetails = _converter.ClientToModel(client, clientExtraInfoList, companies, companyExtraInfoList);
                operation.Result = clientDetails;
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
                operation.Status = HttpStatusCode.InternalServerError;
                operation.Exception = ex;
            }
            return operation;
        }

    }
}
