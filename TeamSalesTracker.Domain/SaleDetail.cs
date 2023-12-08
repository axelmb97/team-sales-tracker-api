using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain
{
    public class SaleDetail
    {
        public long SaleDetailId { get; set; }
        //public long ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
        //public long SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
