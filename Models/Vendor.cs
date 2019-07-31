using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            ProductVendor = new HashSet<ProductVendor>();
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
            VendorAddress = new HashSet<VendorAddress>();
            VendorContact = new HashSet<VendorContact>();
        }

        public int VendorId { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public byte CreditRating { get; set; }
        public bool? PreferredVendorStatus { get; set; }
        public bool? ActiveFlag { get; set; }
        public string PurchasingWebServiceUrl { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<ProductVendor> ProductVendor { get; set; }
        public ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        public ICollection<VendorAddress> VendorAddress { get; set; }
        public ICollection<VendorContact> VendorContact { get; set; }
    }
}
