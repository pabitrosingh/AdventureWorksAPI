using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class Document
    {
        public Document()
        {
            ProductDocument = new HashSet<ProductDocument>();
        }

        public int DocumentId { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Revision { get; set; }
        public int ChangeNumber { get; set; }
        public byte Status { get; set; }
        public string DocumentSummary { get; set; }
        public byte[] Document1 { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<ProductDocument> ProductDocument { get; set; }
    }
}
