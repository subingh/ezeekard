using EzeeKards.Service.Models.Users;
using LogBook.Common.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Service.Interfaces
{
    public interface ICompanyExtraInfoService
    {
        Task<OperationResult<ExtraInfoCompanyResponse>> CreateCompanyExtraInfoAsync(ExtraInfoCompanyRequest request, Guid companyId);
        Task<OperationResult<ExtraInfoCompanyResponse>> UpdateCompanyExtraInfoAsync(Guid extraInfoId, ExtraInfoCompanyRequest request);
        Task<OperationResult<ExtraInfoCompanyResponse>> DeleteExtraInfoAsync(Guid extraInfoId);
        Task<OperationResult<ExtraInfoCompanyResponse>> GetByIdAsync(Guid extraInfoId);
        Task<OperationResult<IEnumerable<ExtraInfoCompanyResponse>>> GetAllAsync();
    }
}
