namespace LogBook.Common.Models.Responses
{
    public class ResponseModel<TResult> where TResult : class
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 20;
        public int Total { get; set; }
        public TResult Result { get; set; }
    }
}
