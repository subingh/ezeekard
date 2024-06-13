using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EzeeKard.Models
{
    public class ExtraInfo : Base
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
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
