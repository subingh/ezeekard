using EzeeKards.Service.Models.Users;
using LogBook.Common.Models.Responses;

namespace EzeeKards.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<OperationResult<CompanyResponse>> CreateCompanyAsync(CompanyRequest request, Guid clientId);
        Task<OperationResult<CompanyResponse>> UpdateCompanyAsync(Guid CompanyId, CompanyRequest request);
        Task<OperationResult<CompanyResponse>> DeleteCompanyAsync(Guid companyId);
        Task<OperationResult<CompanyResponse>> GetByIdAsync(Guid companyId);
        Task<OperationResult<IEnumerable<CompanyResponse>>> GetAllAsync();
    }
}