using System.ComponentModel.DataAnnotations;

namespace EzeeKards.Data.Entities.Domain
{
    public class SocialMedia : Base
    {
        [Key]
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public string LogoUrl { get; set; }
        
    }
}
