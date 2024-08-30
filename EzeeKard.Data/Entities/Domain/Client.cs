using System.ComponentModel.DataAnnotations;

namespace EzeeKards.Data.Entities.Domain
{
    public class Client : Base
    {
        public Guid ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName {  get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }

        // Navigation properties
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<ClientExtraInfo> ClientExtraInfos { get; set; }
    }
}
