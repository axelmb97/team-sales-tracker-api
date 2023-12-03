using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Extensions;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Services.Implementations
{
    public class PaginationService : IPaginationService
    {
        private readonly SalesTrackerDB _data;
        public PaginationService(SalesTrackerDB data)
        {
            _data = data;
        }

        public async Task<Pagination<T>> CreatePageGenericResults<T>(IQueryable<T> queryable, int page, int pageSize, string orderBy, bool ascending)
        {
            var skipAmount = pageSize * (page - 1);
            var numberOfRecords = await queryable.CountAsync();
            var result = new List<T>();

            if (orderBy is null)
            {
                result = await queryable.Skip(skipAmount).Take(pageSize).ToListAsync();
            }
            else {
                result = await queryable
                    .OrderByPropertyOrField(orderBy, ascending)
                    .Skip(skipAmount)
                    .Take(pageSize).ToListAsync();
            }
            var remainder = numberOfRecords % pageSize;
            var totalPageCount = (numberOfRecords / pageSize) + (remainder == 0 ? 0 : 1);

            var pagination = new Pagination<T>
            {
                Items = result,
                PageNumber = page,
                TotalItems = numberOfRecords,
                TotalPages = totalPageCount
            };
            return pagination;
        }
    }
}
