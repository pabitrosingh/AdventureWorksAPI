using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class ProductVendor
    {
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public int AverageLeadTime { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal? LastReceiptCost { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int? OnOrderQty { get; set; }
        public string UnitMeasureCode { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Product Product { get; set; }
        public UnitMeasure UnitMeasureCodeNavigation { get; set; }
        public Vendor Vendor { get; set; }
    }
}
