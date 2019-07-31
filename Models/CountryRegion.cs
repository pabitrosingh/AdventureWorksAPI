using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class CountryRegion
    {
        public CountryRegion()
        {
            CountryRegionCurrency = new HashSet<CountryRegionCurrency>();
            StateProvince = new HashSet<StateProvince>();
        }

        public string CountryRegionCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<CountryRegionCurrency> CountryRegionCurrency { get; set; }
        public ICollection<StateProvince> StateProvince { get; set; }
    }
}
