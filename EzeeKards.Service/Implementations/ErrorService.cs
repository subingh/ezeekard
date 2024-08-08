using EzeeKard.Data.Entities.Dtos;
using EzeeKard.Service.Converters;
using EzeeKard.Service.Interfaces;
using EzeeKards.Common.Helpers;
using EzeeKards.Data.Database;
using LogBook.Common.Helpers;
using LogBook.Common.Models.Responses;
using Microsoft.Extensions.Logging;

namespace EzeeKards.Service.Implementation
{
    public class ErrorService : IErrorService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ErrorConverter _converter;
        private readonly ILogger<ErrorService> _logger;
        public ErrorService(ApplicationDbContext dbContext, ErrorConverter converter, ILogger<ErrorService> logger)
        {
            _dbContext = dbContext;
            _converter = converter;
            _logger = logger;
        }

        /// <summary>
        /// Creates a error information
        /// Used to handle and keep records of exceptions and error throughout the program
        /// </summary>
        /// <param name="errorDTO"></param>
        /// <returns></returns>
        public async Task<OperationResult<ErrorDTO>> CreateAsync(ErrorDTO errorDTO)
        {
            var operation = new OperationResult<ErrorDTO>
            {
                Result = new ErrorDTO()
            };
            try
            {
                var errorDomainModel = _converter.ToDomain(errorDTO);
                _dbContext.Error.Add(errorDomainModel);
                var result = await _dbContext.SaveChangesAsync();

                var createdErrorDTO = _converter.ToDTO(errorDomainModel);
                operation.Result = createdErrorDTO;
            }
            catch (Exception ex)
            {
                operation.Exception = ex;
                throw;
            }
            return operation;
        }

        public async Task Exception<T>(OperationResult<T> errorDTO, Exception ex)
        {
            errorDTO.Exception =ex;
            errorDTO.Status = System.Net.HttpStatusCode.InternalServerError;
            await CreateAsync(new ErrorDTO
            {
                
                Message = ExceptionHelper.GetExceptionMessage(ex),
                TimeStamp = NepalTime.Now
            });
            _logger.LogError(ex, "An exception occurred.");
        }
    }
}