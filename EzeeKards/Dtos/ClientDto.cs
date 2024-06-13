namespace EzeeKards.Dtos.Client
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string ImageUrl { get; set; }
        public List<CompanyDto> Companies { get; set; }
        public List<ExtraInfoDto> ExtraInfos { get; set; }

    }
}
