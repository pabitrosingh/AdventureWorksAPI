using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class VendorContact
    {
        public int VendorId { get; set; }
        public int ContactId { get; set; }
        public int ContactTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Contact Contact { get; set; }
        public ContactType ContactType { get; set; }
        public Vendor Vendor { get; set; }
    }
}
