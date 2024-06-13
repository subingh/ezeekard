using System.ComponentModel.DataAnnotations;

namespace EzeeKard.Models
{
    public class SocialMedia : Base
    {
        [Key]
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public string LogoUrl { get; set; }
        
    }
}
