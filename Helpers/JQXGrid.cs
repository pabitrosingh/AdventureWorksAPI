using System.Collections.Generic;

namespace AdventureWorksAPI.Helpers
{
    public class JQXGrid
    {
        public int filterscount { get; set; }
        public int groupscount { get; set; }
        public string sortdatafield { get; set; }
        public sortorder sortorder { get; set; }
        public int pagenum { get; set; }
        public int pagesize { get; set; }
        public int recordstartindex { get; set; }
        public int recordendindex { get; set; }
        public string filterdatafield { get; set; }
        public filtercondition filtercondition { get; set; }
        public string filtervalue { get; set; }
        public filteroperator filteroperator { get; set; }
        public List<filterGroups> filterGroups { get; set; }
    }

    public class filterGroups
    {
        public string field { get; set; }
        public List<filters> filters { get; set; }
    }

    public class filters
    {
        public string label { get; set; }
        public string value { get; set; }
        public string condition { get; set; }
         public string field { get; set; }
        public string type { get; set; }
        
        // public int operator { get; set; }
        
        

    }
    public enum  filteroperator {
        AND ,
        OR
    }

    public enum sortorder
    {
        asc,
        desc
    }
    public enum filtercondition
    {
        CONTAINS, 
        CONTAINS_CASE_SENSITIVE,
        DOES_NOT_CONTAIN, 
        DOES_NOT_CONTAIN_CASE_SENSITIVE,
        EQUAL,
        EQUAL_CASE_SENSITIVE,
        NOT_EQUAL,
        GREATER_THAN,
        GREATER_THAN_OR_EQUAL,
        LESS_THAN,
        LESS_THAN_OR_EQUAL,
        STARTS_WITH, 
        STARTS_WITH_CASE_SENSITIVE, 
        ENDS_WITH,
        ENDS_WITH_CASE_SENSITIVE,
        NULL,
        NOT_NULL, 
        EMPTY,
        NOT_EMPTY
    }
}