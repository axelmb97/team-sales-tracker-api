﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSalesTrackerApi.Models
{
    [Table("ADDRESSES")]
    public class Address
    {
        [Column("address_id")]
        public long AddressId { get; set; }
        [Column("street_name")]
        public string StreetName { get; set; }
        [Column("street_number")]
        public long StreetNumber { get; set; }
        [Column("zip_code")]
        public string ZipCode { get; set; }
        [Column("apartment")]
        public string Apartment { get; set; }
        [Column("branch_id")]
        public long? BranchId { get; set; }
        public Branch Branch { get; set; }
        [Column("user_id")]
        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
