using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("PRODUCTS")]
    public class Product
    {
        [Column("product_id")]
        public long ProductId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("remarks")]
        public string Remarks { get; set; }
    }
}
