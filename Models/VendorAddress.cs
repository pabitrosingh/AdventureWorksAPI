using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class VendorAddress
    {
        public int VendorId { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Address Address { get; set; }
        public AddressType AddressType { get; set; }
        public Vendor Vendor { get; set; }
    }
}
