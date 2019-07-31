using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class Store
    {
        public Store()
        {
            StoreContact = new HashSet<StoreContact>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int? SalesPersonId { get; set; }
        public string Demographics { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Customer Customer { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public ICollection<StoreContact> StoreContact { get; set; }
    }
}
