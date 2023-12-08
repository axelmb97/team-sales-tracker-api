﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSalesTracker.Domain
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
    }
}
