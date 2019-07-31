using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace AdventureWorksAPI.Models
{
    //[Table("vEmployee")]
    public class EmployeeView
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string DepartmentGroup { get; set; }
        public short Grade_Band { get; set; }
        public DateTime HireDate { get; set; }
        public string CurrentShift { get; set; }
        public short SL { get; set; }
        public short EL { get; set; }
        public short BL { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string CountryRegionName { get; set; }
        public string StateProvinceName { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public int ManagerID { get; set; }
    }
}
