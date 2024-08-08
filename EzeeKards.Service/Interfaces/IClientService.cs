using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Models.Users;
using LogBook.Common.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EzeeKard.Service.Implementations
{
    public interface IClientService
    {
        Task<OperationResult<ClientResponse>> CreateClientAsync([FromForm]ClientRequest request);
        Task<OperationResult<ClientResponse>> UpdateClientAsync(Guid Id, ClientRequest request);
        Task<OperationResult<ClientResponse>> DeleteClientAsync(Guid clientId);
        Task<OperationResult<IEnumerable<ClientResponse>>> GetAllAsync();
        Task<OperationResult<ClientResponse>> GetByIdAsync(Guid clientId);
    }
}
