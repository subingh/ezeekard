using EzeeKards.Service.Models.Users;
using LogBook.Common.Models.Responses;

namespace EzeeKards.Service.Interfaces
{
    public interface IClientInformationService
    {
        Task<OperationResult<List<ClientDetails>>> GetAllAsync();
        Task<OperationResult<List<ClientDetails>>> GetByIdAsync(Guid clientId);
    }
}