using TeamSalesTrackerApi.Dtos;

namespace TeamSalesTrackerApi.Services.Interfaces
{
    public interface IPaginationService
    {
        Task<Pagination<T>> CreatePageGenericResults<T>(IQueryable<T> queryable,
            int page,
            int pageSize,
            string orderBy,
            bool ascending);
    }
}
