using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class SalesPersonQuotaHistory
    {
        public int SalesPersonId { get; set; }
        public DateTime QuotaDate { get; set; }
        public decimal SalesQuota { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public SalesPerson SalesPerson { get; set; }
    }
}
