using EzeeKards.Service.Models.Users;
using LogBook.Common.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Service.Interfaces
{
    public interface IClientExtraInfoService
    {
        Task<OperationResult<ExtraInfoClientResponse>> CreateClientExtraInfoAsync(ExtraInfoClientRequest request, Guid clientId);
        Task<OperationResult<ExtraInfoClientResponse>> UpdateClientExtraInfoAsync(Guid extraInfoId, ExtraInfoClientRequest request);
        Task<OperationResult<ExtraInfoClientResponse>> DeleteExtraInfoAsync(Guid extraInfoId);
        Task<OperationResult<ExtraInfoClientResponse>> GetByIdAsync(Guid extraInfoId);
        Task<OperationResult<IEnumerable<ExtraInfoClientResponse>>> GetAllAsync();
    }
}
