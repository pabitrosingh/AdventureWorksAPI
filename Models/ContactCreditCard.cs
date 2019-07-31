using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class ContactCreditCard
    {
        public int ContactId { get; set; }
        public int CreditCardId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Contact Contact { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
