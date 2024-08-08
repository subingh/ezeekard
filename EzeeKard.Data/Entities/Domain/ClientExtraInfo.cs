using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EzeeKards.Data.Entities.Domain
{
    public class ClientExtraInfo : Base
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Client")]
        public Guid ClientId { get; set; }

        public string CCountry { get; set; }

        public string CState { get; set; }

        public string CCity { get; set; }

        public string CStreet { get; set; }

        public string CMapUrl { get; set; }

        public string CPhoneNumber { get; set; }

        public string CEmail { get; set; }

        public string CWebsite { get; set; }

        public string CDescription { get; set; }

        public string CSocialMedias { get; set; }

        // Navigation Property
        public Client Client { get; set; }
    }
}
