using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("BRANCHES")]
    public class Branch
    {
        [Column("branch_id")]
        public long BranchId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("branch_number")]
        public long BranchNumber { get; set; }
        public virtual Address Address { get; set; }

        public List<Sale> Sales { get; set; }
    }
}
