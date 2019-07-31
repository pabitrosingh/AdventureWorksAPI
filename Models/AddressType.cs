using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class AddressType
    {
        public AddressType()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
            VendorAddress = new HashSet<VendorAddress>();
        }

        public int AddressTypeId { get; set; }
        public string Name { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<CustomerAddress> CustomerAddress { get; set; }
        public ICollection<VendorAddress> VendorAddress { get; set; }
    }
}
