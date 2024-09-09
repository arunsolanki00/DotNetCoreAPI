namespace EvinceDevPracticalTest.Models
{
    public class PagingModel
    {
        public string SearchColumn { get; set; }
        public string Search { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; }
    }
}
