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


namespace AdventureWorksAPI.DB
{
    public class HRDBRepository : IHRDBRepository
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

        public HRDBRepository(IConfiguration configuration,
                            ILogger<HRDBRepository> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }


        public async Task<List<object>> GetEmployee()
        {
            string SQLQuery = "SELECT * FROM [HumanResources].[vEmployee]";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery);
                return resultSet.ToList();
            }
        }

        public async Task<object> GetEmployee(int empid)
        {
            string SQLQuery = "SELECT * FROM [HumanResources].[VW_Employee] WHERE BusinessEntityID = @empid";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery,new { empid = empid });
                return resultSet;
            }
        }

        public async Task<IEnumerable<object>> GetCurrentYearTerritorySalesReport()
        {
            string SQLQuery = @"select year(s.OrderDate) as 'Year', 
                                t.Name,
                                SUM(s.TotalDue) as 'Sales' 
                                from Sales.SalesOrderHeader s
                                join Sales.SalesTerritory t
                                on t.TerritoryID = s.TerritoryID
                                where year(s.OrderDate)=2014
                                group by year(s.OrderDate) , t.TerritoryID, t.Name
                                order by year(s.OrderDate) desc";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery);
                return resultSet;
            }
        }

        public async Task<List<object>> GetCurrentYearQuaterlyProductSalesReport()
        {
            string SQLQuery = @"select year(h.OrderDate) as 'Year',
	                            datepart(QQ,h.OrderDate) as 'Quater',
	                            c.Name,
	                            sum(s.LineTotal) as 'Sales'
                                from Sales.SalesOrderDetail s
                                join Production.Product p 
                                on p.ProductID = s.ProductID
                                join Production.ProductCategory c
                                on p.ProductSubcategoryID =c.ProductCategoryID
                                join Sales.SalesOrderHeader h
                                on h.SalesOrderID = s.SalesOrderID
                                where year(h.OrderDate)=2013
                                group by year(h.OrderDate) , datepart(QQ,h.OrderDate) ,c.ProductCategoryID, c.Name  
                                order by year(h.OrderDate) desc ,datepart(QQ,h.OrderDate) asc, c.Name asc";

            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery);
                return resultSet.ToList();
            }
        }

        
    }


    //View Models POCO Classes

    public class ProductInventoryStockViewModel
    {
        public int ProductID { get; set; }
        public int CurrentStock { get; set; }
        public int SafetyStockLevel { get; set; }
    } 
}
