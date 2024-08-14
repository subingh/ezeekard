using EzeeKards.Data.Entities.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Service.Models.Users
{
    public class CompanyRequest
    {
        public string CompanyName { get; set; }
        public IFormFile CompanyLogo { get; set; }
        
    }
    public class CompanyResponse: Base
    {
        public Guid ClientId { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
    }

  
}
