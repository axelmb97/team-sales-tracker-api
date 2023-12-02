using TeamSalesTrackerApi.Models;

namespace TeamSalesTrackerApi.Results.Products
{
    public class ProductsResult : BaseResult
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
