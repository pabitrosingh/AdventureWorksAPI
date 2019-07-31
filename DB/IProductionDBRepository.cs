using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.DB
{
    public interface IProductionDBRepository
    {
         Task<IEnumerable<ProductInventoryStockViewModel>> GetProductInventoryStockFromDB();
         Task<IEnumerable<object>> GetAssemblyLineRecordsFromDB(string locationID);
        Task<IEnumerable<object>> GetWorkOrderDetailsFromDB(string workOrderType);
        Task<IEnumerable<object>> GetProductInventoryDetailsFromDB();
    }
}