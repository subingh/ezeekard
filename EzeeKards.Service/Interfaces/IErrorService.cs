using EzeeKard.Data.Entities.Dtos;
using LogBook.Common.Models.Responses;

namespace EzeeKard.Service.Interfaces
{
    public interface IErrorService
    {
        Task <OperationResult<ErrorDTO>>CreateAsync(ErrorDTO errorDTO);
        Task Exception<T> (OperationResult<T> errorDTO, Exception ex);
    }
}