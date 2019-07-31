using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AdventureWorksAPI.DB
{
    public sealed class ProductionDBRepository :IProductionDBRepository
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

        
        public ProductionDBRepository(IConfiguration configuration,
                            ILogger<ProductionDBRepository> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<IEnumerable<ProductInventoryStockViewModel>> GetProductInventoryStockFromDB()
        {
            string SQLQuery = @"select p.ProductID , SUM(i.Quantity) as 'CurrentStock', p.SafetyStockLevel
                                from Production.Product p
                                join  Production.ProductInventory i
                                on p.ProductID = i.ProductID
                                group by p.ProductID  , p.SafetyStockLevel";

            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<ProductInventoryStockViewModel>(SQLQuery);
                return resultSet.ToList();
            }
        }     

        public async Task<IEnumerable<object>> GetAssemblyLineRecordsFromDB(string LocationID)
        {
            string SQLQuery = @"select wr.WorkOrderID ,
                                p.Name as 'ProductName',
                                wo.OrderQty,
                                'CurrentStage'= case(wr.OperationSequence)
                                when 1 then 'Forming'
                                when 2 then 'Welding'
                                when 3 then 'Debur and Polish'
                                when 4 then 'Paint'
                                when 5 then 'Specialized Paint'
                                when 6 then 'Subassembly'
                                when 7 then 'Final Assembly'
                                end,
                                'AssemblyArea'= case(wr.LocationID)
                                when 10 then 'Frame Forming'
                                when 20 then 'Frame Welding'
                                when 30 then 'Debur and Polish'
                                when 40 then 'Paint Zone'
                                when 45 then 'Specialized Paint'
                                when 50 then 'Subassembly'
                                when 60 then 'Final Assembly'
                                end,
                                wr.ActualResourceHrs,
                                wr.ActualCost,
                                format(wr.ActualStartDate,'yyyy-MM-dd') as 'StartDate',
                                format(wr.ActualEndDate,'yyyy-MM-dd') as 'EndDate'
                                from Production.WorkOrderRouting wr
                                join Production.Product p 
                                on p.ProductID = wr.ProductID
                                join Production.WorkOrder wo 
                                on wr.WorkOrderID = wo.WorkOrderID
                                where LocationID=@ID";

            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery,new {ID = LocationID});
                return resultSet.ToList();
            }
        }        
    
        public async Task<IEnumerable<object>> GetWorkOrderDetailsFromDB(string WorkOrderType)
        {
            string SQLQuery = string.Empty;
            if (WorkOrderType=="Received")
            {
                SQLQuery =@"select wo.WorkOrderID,
                            wo.ProductID,
                            wo.OrderQty,
                            wo.StockedQty,
                            format(wo.StartDate,'yyyy-MM-dd') as 'StartDate',
                            format(wo.EndDate,'yyyy-MM-dd') as 'EndDate',
                            format(wo.DueDate,'yyyy-MM-dd') as 'DueDate'
                            from Production.WorkOrder wo
                            where WorkOrderID not in (select WorkOrderID from Production.WorkOrderRouting)";
            }

            if (WorkOrderType=="Completed")
            {
                SQLQuery =@"select wo.WorkOrderID,
                            wo.ProductID,
                            wo.OrderQty,
                            wo.StockedQty,
                            format(wo.StartDate,'yyyy-MM-dd') as 'StartDate',
                            format(wo.EndDate,'yyyy-MM-dd') as 'EndDate',
                            format(wo.DueDate,'yyyy-MM-dd') as 'DueDate'
                            from Production.WorkOrder wo
                            where wo.EndDate < = wo.DueDate
                            and wo.ScrapReasonID is null";
            }

            if (WorkOrderType=="Delayed")
            {
                SQLQuery =@"select wo.WorkOrderID,
                        wo.ProductID,
                        wo.OrderQty,
                        wo.StockedQty,
                        format(wo.StartDate,'yyyy-MM-dd') as 'StartDate',
                        format(wo.EndDate,'yyyy-MM-dd') as 'EndDate',
                        format(wo.DueDate,'yyyy-MM-dd') as 'DueDate'
                        from Production.WorkOrder wo
                        where wo.EndDate > wo.DueDate
                        and wo.ScrapReasonID is null";
            }

            if (WorkOrderType=="Scraped")
            {
                SQLQuery =@"select wo.WorkOrderID,
                            wo.ProductID,
                            wo.OrderQty,
                            wo.StockedQty,
                            wo.ScrappedQty,
                            r.Name
                            from Production.WorkOrder wo 
                            join Production.ScrapReason r
                            on wo.ScrapReasonID = r.ScrapReasonID
                            where wo.ScrapReasonID is not null";
            }

            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery);
                return resultSet.ToList();
            }
        }

        public async Task<IEnumerable<object>> GetProductInventoryDetailsFromDB()
        {
            string SQLQuery = @"with cte as (
                                select p.ProductID ,p.Name, SUM(i.Quantity) as 'CurrentStock', p.SafetyStockLevel
                                from Production.Product p
                                join  Production.ProductInventory i
                                on p.ProductID = i.ProductID
                                group by p.ProductID  , p.SafetyStockLevel , p.Name)
                                select * from cte order by CurrentStock asc";
            using (IDbConnection conn = DapperConnection)
            {
                conn.Open();
                var resultSet = await conn.QueryAsync<object>(SQLQuery);
                return resultSet.ToList();
            }
        }        
    }
}
