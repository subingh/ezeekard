using EzeeKard.Models;
using EzeeKards.Dtos.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzeeKards.Dtos
{
    public class ExtraInfoDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public ClientDto Client { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string MapUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string SocialMedias { get; set; }
    }
}
