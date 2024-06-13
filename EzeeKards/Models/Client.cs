using System.ComponentModel.DataAnnotations;

namespace EzeeKard.Models
{
    public class Client : Base
    {
        [Key]
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string ImageUrl { get; set; }

        // Navigation properties
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<ExtraInfo> ExtraInfos { get; set; }
    }
}
