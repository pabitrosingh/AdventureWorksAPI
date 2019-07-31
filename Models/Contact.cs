using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class Contact
    {
        public Contact()
        {
            ContactCreditCard = new HashSet<ContactCreditCard>();
            Individual = new HashSet<Individual>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
            StoreContact = new HashSet<StoreContact>();
            VendorContact = new HashSet<VendorContact>();
        }

        public int ContactId { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string EmailAddress { get; set; }
        public int EmailPromotion { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string AdditionalContactInfo { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<ContactCreditCard> ContactCreditCard { get; set; }
        public ICollection<Individual> Individual { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
        public ICollection<StoreContact> StoreContact { get; set; }
        public ICollection<VendorContact> VendorContact { get; set; }
    }
}
