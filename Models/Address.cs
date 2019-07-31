using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class Address
    {
        public Address()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
            EmployeeAddress = new HashSet<EmployeeAddress>();
            SalesOrderHeaderBillToAddress = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddress = new HashSet<SalesOrderHeader>();
            VendorAddress = new HashSet<VendorAddress>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceId { get; set; }
        public string PostalCode { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public StateProvince StateProvince { get; set; }
        public ICollection<CustomerAddress> CustomerAddress { get; set; }
        public ICollection<EmployeeAddress> EmployeeAddress { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddress { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddress { get; set; }
        public ICollection<VendorAddress> VendorAddress { get; set; }
    }
}
