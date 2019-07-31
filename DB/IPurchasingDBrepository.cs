using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPurchasingDBrepository
{
     Task<IEnumerable<object>> GetVendorDetailsFromDB();
    Task<IEnumerable<object>> GetLowRunningStockFromDB();
    Task<IEnumerable<object>> PurchaseOrderHeaderFromDB();
}