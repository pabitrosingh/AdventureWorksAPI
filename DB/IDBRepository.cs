using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksAPI.DB
{
    public interface IDBRepository
    {
        Task<List<Object>> GetEmployee();
        Task<Object> GetEmployee(int empid);
        Task<IEnumerable<object>> GetCurrentYearTerritorySalesReport();
        Task<List<object>> GetCurrentYearQuaterlyProductSalesReport();
    }
}
