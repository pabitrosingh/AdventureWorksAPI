using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksAPI.Helpers;
using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksAPI.DB;

namespace AdventureWorksAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductionController : Controller
    {

        private readonly IProductionDBRepository _ProductionDBRepository;
        private readonly AdventureWorksContext _AdventureWorksContext;
        private readonly ILogger _logger;
        private readonly IValidation _validation;

        public ProductionController(AdventureWorksContext adventureWorksContext,
                                    ILogger<ProductionController> logger,
                                    IValidation Validation,
                                    IProductionDBRepository DBRepository)
        {
            _AdventureWorksContext = adventureWorksContext;
            _logger = logger;
            _validation = Validation;
            _ProductionDBRepository = DBRepository;
        }


        //
        [HttpGet]
        public ActionResult<object> GetAssemblyLineCount()
        {
            List<object> AssemblyLineCountReport = null;
            try
            {
                var ret = from wr in _AdventureWorksContext.WorkOrderRouting
                          join l in _AdventureWorksContext.Location
                          on wr.LocationId equals l.LocationId
                          orderby wr.OperationSequence descending
                          group wr by new
                          {
                              wr.LocationId,
                              wr.Location.Name,
                              wr.OperationSequence
                          } into g
                          select new
                          {
                              LocationID = g.Key.LocationId,
                              AssemblyName = g.Key.Name,
                              CountWorkOrder = g.Count(),
                              RoutingSequence = g.Key.OperationSequence
                          };
                AssemblyLineCountReport = ret.ToList<object>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            if (AssemblyLineCountReport.Count != 0)
            {
                return AssemblyLineCountReport;
            }
            else
            {
                return NotFound(string.Format("No Records found for"));
            }

        }

        [HttpGet]
        public ActionResult<object> GetWorkOrderDetailsCount()
        {
            List<object> WorkOrderDetailsReport = new List<object>();
            try
            {
                var ReceivedObj = new
                {
                    name = "Received",
                    value = _AdventureWorksContext.WorkOrder.Count()
                };

                var CompletedObj = new
                {
                    name = "Completed",
                    value = _AdventureWorksContext.WorkOrder.Where(item => item.EndDate <= item.DueDate).Count()
                };

                var DelayedObj = new
                {
                    name = "Delayed",
                    value = _AdventureWorksContext.WorkOrder.Where(item => item.EndDate > item.DueDate).Count()
                };

                var ScrapedObj = new
                {
                    name = "Scraped",
                    value = _AdventureWorksContext.WorkOrder.Where(item => item.ScrapReasonId != null).Count()
                };

                WorkOrderDetailsReport.Add(ReceivedObj);
                WorkOrderDetailsReport.Add(CompletedObj);
                WorkOrderDetailsReport.Add(DelayedObj);
                WorkOrderDetailsReport.Add(ScrapedObj);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            if (WorkOrderDetailsReport.Count != 0)
            {
                return WorkOrderDetailsReport;
            }
            else
            {
                return NotFound(string.Format("No Records found for"));
            }

        }

        [HttpGet]
        public async Task<ActionResult<object>> GetStockInventoryCount()
        {
            List<object> StockInventoryReport = new List<object>();
            try
            {

                IEnumerable<ProductInventoryStockViewModel> ResultSet = await _ProductionDBRepository.GetProductInventoryStockFromDB();

                var InStock = new
                {
                    name = "In-Stock",
                    value = ResultSet.Where(p => p.CurrentStock > p.SafetyStockLevel).Count()
                };

                var RunningLow = new
                {
                    name = "Running Low",
                    value = ResultSet.Where(p => p.CurrentStock < p.SafetyStockLevel && p.CurrentStock != 0).Count()
                };

                var OutOfStock = new
                {
                    name = "Out Of Stock",
                    value = ResultSet.Where(p => p.CurrentStock == 0).Count()
                };
                StockInventoryReport.Add(InStock);
                StockInventoryReport.Add(RunningLow);
                StockInventoryReport.Add(OutOfStock);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            if (StockInventoryReport.Count != 0)
            {
                return StockInventoryReport;
            }
            else
            {
                return NotFound(string.Format("No Records found for"));
            }

        }

        [HttpGet]
        [Route("{locationID}")]
        public async Task<ActionResult> GetAssemblyLineRecords(string locationID, [FromQuery] JQXGrid JQXGrid)
        {
            if (!string.IsNullOrWhiteSpace(locationID) && !_validation.IsXSS(locationID) && _validation.IsValidLocationID(locationID))
            {
                var ResultSet = await _ProductionDBRepository.GetAssemblyLineRecordsFromDB(locationID);
                var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
                var jsonResp = new
                {
                    root = Records,
                    totalrecords = ResultSet.ToList().Count()
                };
                return Json(jsonResp);
            }
            return NotFound("Valid required paramenters not supplied");
        }

        [HttpGet]
        [Route("{WorkOrderType}")]
        public async Task<ActionResult> GetWorkOrderDetails(string WorkOrderType, [FromQuery] JQXGrid JQXGrid)
        {
            if (!string.IsNullOrWhiteSpace(WorkOrderType) && !_validation.IsXSS(WorkOrderType) && _validation.IsValidName(WorkOrderType))
            {
                var ResultSet = await _ProductionDBRepository.GetWorkOrderDetailsFromDB(WorkOrderType);
                var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
                var jsonResp = new
                {
                    root = Records,
                    totalrecords = ResultSet.ToList().Count()
                };
                return Json(jsonResp);
            }
            return NotFound("Valid required paramenters not supplied");
        }


        [HttpGet]
        public async Task<ActionResult> GetProductInventoryDetails([FromQuery] JQXGrid JQXGrid)
        {
            var ResultSet = await _ProductionDBRepository.GetProductInventoryDetailsFromDB();
            var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
            var jsonResp = new
            {
                root = Records,
                totalrecords = ResultSet.ToList().Count()
            };
            return Json(jsonResp);
        }
    }
}