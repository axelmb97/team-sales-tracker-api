using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Dtos
{
    public class BranchDto
    {
        public long BranchId { get; set; }
        public string Name { get; set; }
        public long BranchNumber { get; set; }
        public long AddressId { get; set; }
        public string StreetName { get; set; }
        public long StreetNumber { get; set; }
    }
}
