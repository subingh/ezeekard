using EzeeKards.Dtos.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace EzeeKards.Dtos
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public ClientDto Client { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public List<ExtraInfoDto> ExtraInfos { get; set; }
    }
}
