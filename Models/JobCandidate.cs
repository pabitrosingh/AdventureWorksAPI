using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class JobCandidate
    {
        public int JobCandidateId { get; set; }
        public int? EmployeeId { get; set; }
        public string Resume { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Employee Employee { get; set; }
    }
}
