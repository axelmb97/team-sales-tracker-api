namespace TeamSalesTrackerApi.Business.Commands
{
    public class PaginationCommand
    {
        public int PageNumber { get; set; } = 0;
        public int pageSize { get; set; } = 15;
        public string? OrderBy { get; set; } = "Name";
        public bool OrderAsc { get; set; } = true;
        public PaginationCommand()
        {

        }
    }
}
