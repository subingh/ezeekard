using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EzeeKard.Models
{
    public class Company : Base
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }


        
        // Navigation properties
        public virtual ICollection<ExtraInfo>? ExtraInfos { get; set; }
    }
}
