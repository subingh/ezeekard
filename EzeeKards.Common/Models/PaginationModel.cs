namespace LogBook.Common.Models
{
    public class PaginationModel<T>
    {
        public int ResultCount { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<T> Items { get; set; }

    }
}
