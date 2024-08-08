using EzeeKard.Data.Entities.Dtos;
using EzeeKards.Data.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKard.Service.Converters
{
    public class ErrorConverter
    {
        public ErrorDTO ToDTO(Error errorDomainModel) 
        {
            if(errorDomainModel == null)
            {
                throw new ArgumentNullException(nameof(errorDomainModel));
            }
            return new ErrorDTO
            {
                ErrorId = errorDomainModel.ErrorId,
                ErrorType = errorDomainModel.ErrorType,
                Message = errorDomainModel.Message,
                TimeStamp = errorDomainModel.TimeStamp,
            };
        }
        public Error ToDomain(ErrorDTO errorDto) 
        {
            if (errorDto == null)
            {
                throw new ArgumentNullException(nameof(errorDto));
            }
            return new Error
            {
                ErrorId = errorDto.ErrorId,
                ErrorType = errorDto.ErrorType,
                Message = errorDto.Message,
                TimeStamp = errorDto.TimeStamp
            };
        }
    }
}
