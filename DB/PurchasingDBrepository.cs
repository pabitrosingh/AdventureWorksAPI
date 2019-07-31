using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class PurchasingDBrepository : IPurchasingDBrepository
{

    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public IDbConnection DapperConnection
    {
        get
        {
            return new SqlConnection(_configuration.GetConnectionString("AdventureWorksDatabase"));
        }
    }

    public PurchasingDBrepository(IConfiguration configuration, ILogger<PurchasingDBrepository> logger)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<IEnumerable<object>> GetVendorDetailsFromDB()
    {
        string SQLQuery = @"select va.BusinessEntityID,
                            va.Name as 'VendorName',
                            va.AddressLine1,
                            va.AddressLine2, 
                            va.City,
                            va.StateProvinceName,
                            va.CountryRegionName,
                            va.PostalCode,
                            vc.ContactType,
                            vc.FirstName,
                            vc.MiddleName,
                            vc.LastName,
                            vc.PhoneNumber,
                            vc.EmailAddress 
                        from Purchasing.vVendorWithAddresses va
                        join Purchasing.vVendorWithContacts vc
                        on va.BusinessEntityID = vc.BusinessEntityID";
        using (IDbConnection conn = DapperConnection)
        {
            conn.Open();
            var resultSet = await conn.QueryAsync<object>(SQLQuery);
            return resultSet;
        }
    }

    public async Task<IEnumerable<object>> GetLowRunningStockFromDB()
    {
        string SQLQuery = @"with cte as (
                            select p.ProductID ,p.Name,  SUM(i.Quantity) as 'CurrentStock', p.SafetyStockLevel
                            from Production.Product p
                            join  Production.ProductInventory i
                            on p.ProductID = i.ProductID
                            group by p.ProductID  ,p.Name, p.SafetyStockLevel)
                            select * from cte
                            where CurrentStock <= SafetyStockLevel
                            order by CurrentStock asc";
        using (IDbConnection conn = DapperConnection)
        {
            conn.Open();
            var resultSet = await conn.QueryAsync<object>(SQLQuery);
            return resultSet;
        }
    }

    public async Task<IEnumerable<object>> PurchaseOrderHeaderFromDB()
    {
        string SQLQuery = @"select poh.PurchaseOrderID,
                            format(poh.OrderDate,'yyyy-MM-dd') as 'OrderDate',
                            poh.RevisionNumber,
                            'Status'=case(poh.Status)
                                        when '1' then 'Pending'
                                        when '2' then 'Approved'
                                        when '3' then 'Rejected'
                                        when '4' then 'Complete '
                                        end,
                                        p.FirstName+space(2)+p.LastName 'PlacedBy',
                                        poh.VendorID,
                                        sm.Name as 'ShippedThrough',
                                        poh.SubTotal,
                                        poh.Freight,
                                        poh.TaxAmt,
                                        poh.TotalDue
                        from Purchasing.PurchaseOrderHeader poh
                        join Purchasing.ShipMethod sm
                        on poh.ShipMethodID = sm.ShipMethodID
                        join HumanResources.Employee e
                        on poh.EmployeeID = e.BusinessEntityID
                        join Person.Person p 
                        on e.BusinessEntityID = p.BusinessEntityID";
        using (IDbConnection conn = DapperConnection)
        {
            conn.Open();
            var resultSet = await conn.QueryAsync<object>(SQLQuery);
            return resultSet;
        }
    }
}