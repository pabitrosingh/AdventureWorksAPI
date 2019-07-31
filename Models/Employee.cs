using System;
using System.Collections.Generic;

namespace AdventureWorksAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeAddress = new HashSet<EmployeeAddress>();
            EmployeeDepartmentHistory = new HashSet<EmployeeDepartmentHistory>();
            EmployeePayHistory = new HashSet<EmployeePayHistory>();
            InverseManager = new HashSet<Employee>();
            JobCandidate = new HashSet<JobCandidate>();
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
        }

        public int EmployeeId { get; set; }
        public string NationalIdnumber { get; set; }
        public int ContactId { get; set; }
        public string LoginId { get; set; }
        public int? ManagerId { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool? SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool? CurrentFlag { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Employee Manager { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public ICollection<EmployeeAddress> EmployeeAddress { get; set; }
        public ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
        public ICollection<EmployeePayHistory> EmployeePayHistory { get; set; }
        public ICollection<Employee> InverseManager { get; set; }
        public ICollection<JobCandidate> JobCandidate { get; set; }
        public ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
    }
}
