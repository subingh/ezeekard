using EzeeKards.Data.Entities.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Service.Models.Users
{
    public class ClientRequest
    {
        public string? ClientName { get; set; }
        public IFormFile? Image { get; set; }

    }
    public class ClientResponse: Base
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string Image { get; set; }
    }

}
