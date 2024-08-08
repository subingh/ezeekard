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
        public string ClientName { get; set; }
        public IFormFile Image { get; set; }

    }
    public class ClientResponse
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string Image { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class FileRequest
    {
        public Guid ClientId { set; get; }
        public IEnumerable<string> ClientImage { get; set; }
    }

    public class FileResponse
    {
        public string ClientImage {  get; set; }
    }
}
