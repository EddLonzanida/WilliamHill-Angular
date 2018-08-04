namespace TechChallenge.ApiHost.Dto
{
    public class IndexRequest
    {
        public int Page { get; }

        public int SortColumn { get; }

        public bool IsDescending { get; }

        public string Search { get; }

        public IndexRequest(int? page = 1, bool? desc = false, int? sortColumn = 0, string search = "")
        {
            Page = page ?? 1;
            IsDescending = desc ?? false;
            SortColumn = sortColumn ?? 0;
            Search = search;
        }
    }
}