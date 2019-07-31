using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksAPI.Helpers;
using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksAPI.DB;
using System.Reflection;
using Newtonsoft.Json;

namespace AdventureWorksAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PurchasingController : Controller
    {
        private readonly IPurchasingDBrepository _PurchasingDBrepository;
        private readonly AdventureWorksContext _AdventureWorksContext;
        private readonly ILogger _logger;
        private readonly IValidation _validation;
        public PurchasingController(AdventureWorksContext adventureWorksContext,
                                    ILogger<PurchasingController> logger,
                                    IValidation Validation,
                                    IPurchasingDBrepository PurchasingDBrepository)
        {
             _AdventureWorksContext = adventureWorksContext;
            _logger = logger;
            _validation = Validation;
            _PurchasingDBrepository = PurchasingDBrepository;    
        }

        [HttpGet]
        public  JsonResult GetShippingRateChart([FromQuery] JQXGrid JQXGrid)
        {
            var ResultSet =  _AdventureWorksContext.ShipMethod.Select(s=>s);
            var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
            var jsonResp = new
            {
                root = Records,
                totalrecords = ResultSet.ToList().Count()
            };
            return Json(jsonResp);
            // return Json(ResultSet);
        }

        [HttpGet]
         public async Task<ActionResult> GetVendorDetails([FromQuery] JQXGrid JQXGrid)
         {
             var ResultSet = await _PurchasingDBrepository.GetVendorDetailsFromDB();
             var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
            var jsonResp = new
            {
                root = Records,
                totalrecords = ResultSet.ToList().Count()
            };
            return Json(jsonResp);
            //  return Json(ResultSet);
         }

        [HttpGet]
         public async Task<ActionResult> GetLowRunningStock([FromQuery] JQXGrid JQXGrid)
         {
             var ResultSet = await _PurchasingDBrepository.GetLowRunningStockFromDB();
             var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
            var jsonResp = new
            {
                root = Records,
                totalrecords = ResultSet.ToList().Count()
            };
            return Json(jsonResp);
            //  return Json(ResultSet);
         }

        [HttpGet]
         public async Task<ActionResult> GetPurchaseOrderHeader([FromQuery] JQXGrid JQXGrid)
         {
             var ResultSet = await _PurchasingDBrepository.PurchaseOrderHeaderFromDB();
             var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
             var jsonResp = new
             {
                root = Records,
                totalrecords = ResultSet.ToList().Count()
             };
            return Json(jsonResp);
            //  return Json(ResultSet);
         }

        [HttpGet]
        [Route("{OrderID}")]
         public ActionResult GetPurchaseOrderDetailer(string OrderID, [FromQuery] JQXGrid JQXGrid)
         {
             if(!string.IsNullOrWhiteSpace(OrderID) && !_validation.IsXSS(OrderID) && _validation.IsValidNumber(OrderID))
             {
                int ID = int.Parse(OrderID);
                var ResultSet =  _AdventureWorksContext.PurchaseOrderDetail.Where(p=>p.PurchaseOrderId == ID).Select(p=>p);
                 var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
                var jsonResp = new
                {
                    root = Records,
                    totalrecords = ResultSet.ToList().Count()
                };
                return Json(jsonResp);
                // return Json(ResultSet.ToList());
             }
             else   
             {
               return NotFound("Valid Parameter is not supplied");
             }
         }

    }
}