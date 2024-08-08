using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Service.Converter
{
    public class CompanyConverter
    {
        public Company ToEntity(CompanyRequest request)
        {
            return new Company
            {
                CompanyId = Guid.NewGuid(),
                CompanyName = request.CompanyName,
                CompanyLogo = $"Images/{request.CompanyName}"
            };
        }
        public CompanyResponse ToModel(Company entity)
        {
            return new CompanyResponse
            {
                ClientId = entity.ClientId,
                CompanyId = entity.CompanyId,
                CompanyName = entity.CompanyName,
                CompanyLogo = entity.CompanyLogo,
            };
        }

        public void ToDomain(Company company, CompanyRequest request)
        {
            company.CompanyName = request.CompanyName;
        }
    }
}
