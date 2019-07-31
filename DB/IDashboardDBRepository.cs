using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksAPI.DB
{
    public interface IDashboardDBRepository
    {
        Task<double> GetTotalSalesForTheYearFromDB();
        Task<int> GetTotalCustomersCountFromDB();
        Task<IEnumerable<object>> GetTerritorySalesReportFromDB();
        Task<IEnumerable<object>> GetProductSalesReportFromDB(string Year);
        Task<IEnumerable<object>>  GetPendingShipmentDetailsFromDB();
    }
}