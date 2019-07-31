using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.DB
{
    public sealed class DashboardDBRepository : IDashboardDBRepository
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

        public DashboardDBRepository(IConfiguration configuration,
                            ILogger<DashboardDBRepository> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        
        public async Task<double> GetTotalSalesForTheYearFromDB()
        {
            string SQLQuery = @"select ROUND(SUM(TotalDue),2) from Sales.SalesOrderHeader where YEAR(OrderDate)=2014";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.ExecuteScalarAsync<double>(SQLQuery);
                return  resultSet;
            }
        }
        
        public async Task<int> GetTotalCustomersCountFromDB()
        {
            string SQLQuery = @"select count(*) from Sales.Customer";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.ExecuteScalarAsync<int>(SQLQuery);
                return  resultSet;
            }
        }

        
        public async Task<IEnumerable<object>> GetTerritorySalesReportFromDB()
        {
            string SQLQuery = @"select t.Name as 'name',round(SUM(s.TotalDue),2) as 'value'
                                from Sales.SalesOrderHeader s
                                join Sales.SalesTerritory t
                                on t.TerritoryID = s.TerritoryID
                                where year(s.OrderDate)=2014
                                group by t.Name
                                order by t.Name asc";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery);
                return  resultSet;
            }
        }

        
        public async Task<IEnumerable<object>> GetProductSalesReportFromDB(string Year)
        {
            string SQLQuery = @"select c.Name  as 'name',
                convert(decimal(38,2),sum(s.LineTotal)) as 'value'
                from Sales.SalesOrderDetail s
                join Production.Product p 
                on p.ProductID = s.ProductID
                join Production.ProductCategory c
                on p.ProductSubcategoryID =c.ProductCategoryID
                join Sales.SalesOrderHeader h
                on h.SalesOrderID = s.SalesOrderID
                where year(h.OrderDate)=@year
                group by  c.Name  
                order by c.Name asc";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery,new { year = Year });
                return  resultSet;
            }     
        }

        
        public async Task<IEnumerable<object>> GetPendingShipmentDetailsFromDB()
        {
            string SQLQuery = @"select top(1) concat('#',SalesOrderID,space(2),'Order Date:',format(OrderDate,'yyyy-MM-dd'),
                                space(2),'Ship Date:',format(ShipDate,'yyyy-MM-dd')) as 'title',
                                format(ShipDate,'yyyy-MM-dd') as 'date'
                                from Sales.SalesOrderHeader
                                where year(ShipDate)=2014";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery);
                return  resultSet;
            }     
        }
    }
}