using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksAPI.DB
{
    public interface ISalesDBrepository
    {
         Task<IEnumerable<ProductDetailsViewModel>> GetProductDetailsFromDB();
         Task<IEnumerable<object>> GetSalesOrderHeaderFromDB();
         Task<IEnumerable<object>> GetSalesOrderDetailerFromDB(int SalesORderID);
    }
}