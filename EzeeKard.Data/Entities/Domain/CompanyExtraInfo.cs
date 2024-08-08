using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EzeeKards.Data.Entities.Domain
{
    public class CompanyExtraInfo : Base
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Client")]
        public Guid CompanyId { get; set; }
        public string Designation { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string MapUrl { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }




        // Navigation Property
        public Company Company { get; set; }
        public string SocialMedias { get; set; }
        public string Description { get; set; }
    }
}
