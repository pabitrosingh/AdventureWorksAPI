using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class ContactType
    {
        public ContactType()
        {
            StoreContact = new HashSet<StoreContact>();
            VendorContact = new HashSet<VendorContact>();
        }

        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<StoreContact> StoreContact { get; set; }
        public ICollection<VendorContact> VendorContact { get; set; }
    }
}
