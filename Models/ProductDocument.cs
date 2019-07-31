using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class ProductDocument
    {
        public int ProductId { get; set; }
        public int DocumentId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Document Document { get; set; }
        public Product Product { get; set; }
    }
}
