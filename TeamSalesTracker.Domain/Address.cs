using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain
{
    public class Address
    {
        public long AddressId { get; set; }
        public string StreetName { get; set; }
        public long StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string Apartment { get; set; }
    }
}
