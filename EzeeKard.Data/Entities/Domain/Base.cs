namespace EzeeKards.Data.Entities.Domain
{
    public class Base
    {

        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}
