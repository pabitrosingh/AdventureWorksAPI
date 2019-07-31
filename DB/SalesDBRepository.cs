using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AdventureWorksAPI.DB
{
    public sealed class SalesDBRepository : ISalesDBrepository
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

        public SalesDBRepository(IConfiguration configuration,ILogger<SalesDBRepository> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IEnumerable<ProductDetailsViewModel>> GetProductDetailsFromDB()
        {
            string SQLQuery = @"select  ProductID,
                                        Name,
                                        SubCategory,
                                        Category,
                                        Model,
                                        ProductNumber,
                                        Color,
                                        ListPrice,
                                        Style,
                                        ProductLine,
                                        Class,
                                        Weight,
                                        WeightUnitMeasureCode,
                                        Size,
                                        SizeUnitMeasureCode,
                                        Description
                                from Sales.VW_Products";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<ProductDetailsViewModel>(SQLQuery);
                return resultSet;
            }
        }

        public async Task<IEnumerable<object>> GetSalesOrderHeaderFromDB()
        {
            string SQLQuery = @"select * from Sales.VW_SalesOrderHeader";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery);
                return resultSet;
            }
        }

        public async Task<IEnumerable<object>> GetSalesOrderDetailerFromDB(int SalesORderID)
        {
            string SQLQuery = @"select od.SalesOrderID,
                                od.SalesOrderDetailID,
                                od.ProductID,
                                p.Name,
                                od.UnitPrice,
                                od.OrderQty,
                                od.LineTotal
                                from Sales.SalesOrderDetail od
                                join Production.Product p 
                                on od.ProductID = p.ProductID
                                where od.SalesOrderID = @ID";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery,new { ID = SalesORderID});
                return resultSet;
            }
        }
    }
}