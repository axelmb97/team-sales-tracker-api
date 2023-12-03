using TeamSalesTrackerApi.Dtos;

namespace TeamSalesTrackerApi.Results.Pagination
{
    public class PaginationResult<T>: BaseResult
    {
        public Pagination<T> Result { get; set; }
    }
}
