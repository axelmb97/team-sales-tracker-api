﻿namespace TeamSalesTrackerApi.Dtos
{
    public class Pagination<T>
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }
}
