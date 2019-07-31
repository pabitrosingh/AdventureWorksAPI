using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            ContactCreditCard = new HashSet<ContactCreditCard>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        public int CreditCardId { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<ContactCreditCard> ContactCreditCard { get; set; }
        public ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
