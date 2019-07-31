using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class Individual
    {
        public int CustomerId { get; set; }
        public int ContactId { get; set; }
        public string Demographics { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Contact Contact { get; set; }
        public Customer Customer { get; set; }
    }
}
