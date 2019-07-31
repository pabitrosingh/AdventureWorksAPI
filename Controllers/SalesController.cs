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
    public class SalesController : Controller
    {
        private readonly ISalesDBrepository _SalesDBrepository;
        private readonly AdventureWorksContext _AdventureWorksContext;
        private readonly ILogger _logger;
        private readonly IValidation _validation;

        public SalesController(AdventureWorksContext adventureWorksContext,
                                    ILogger<SalesController> logger,
                                    IValidation Validation,
                                    ISalesDBrepository SalesDBrepository)
        {
            _AdventureWorksContext = adventureWorksContext;
            _logger = logger;
            _validation = Validation;
            _SalesDBrepository = SalesDBrepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProductDetailsViewModel>> GetProductDetails(string PostedData)
        {
            IEnumerable<ProductDetailsViewModel> ResultSet=null;
            ResultSet = await _SalesDBrepository.GetProductDetailsFromDB();
            if (PostedData !=null)
            {
                ProductDetailsFilter  ProductDetailsFilter = JsonConvert.DeserializeObject<ProductDetailsFilter>(PostedData);

                if(!string.IsNullOrWhiteSpace(ProductDetailsFilter.NameProductNumber))
                ResultSet = ResultSet.Where(item=>item.Name.Contains(ProductDetailsFilter.NameProductNumber) || item.ProductNumber.Contains(ProductDetailsFilter.NameProductNumber)).Select(Item=>Item);

                if(!string.IsNullOrWhiteSpace(ProductDetailsFilter.ProductLine))
                ResultSet = ResultSet.Where(item=>item.ProductLine == ProductDetailsFilter.ProductLine).Select(Item=>Item);


                if(!string.IsNullOrWhiteSpace(ProductDetailsFilter.Style))
                ResultSet = ResultSet.Where(item=>item.Style==ProductDetailsFilter.Style).Select(Item=>Item);


                if(!string.IsNullOrWhiteSpace(ProductDetailsFilter.Class))
                ResultSet = ResultSet.Where(item=>item.Class == ProductDetailsFilter.Class).Select(Item=>Item);

                if(!string.IsNullOrWhiteSpace(ProductDetailsFilter.Color))
                ResultSet = ResultSet.Where(item=>item.Color == ProductDetailsFilter.Color).Select(Item=>Item);    

                if(!string.IsNullOrWhiteSpace(ProductDetailsFilter.Category))
                ResultSet = ResultSet.Where(item=>item.Category == ProductDetailsFilter.Category).Select(Item=>Item);    
            }
            return ResultSet;
        }

        [HttpGet]
        [Route("{ImageID}")]
        public ActionResult GetImage(string ImageID)
        {
            try
            {
              int ID = int.Parse(ImageID);
              var ResultSet =(from Photo in _AdventureWorksContext.ProductPhoto 
                            join Prod in _AdventureWorksContext.ProductProductPhoto 
                            on Photo.ProductPhotoId equals Prod.ProductPhotoId
                            where Prod.ProductId==ID
                            select Photo.LargePhoto).FirstOrDefault();    
             if(ResultSet!=null)
             return File(ResultSet,System.Net.Mime.MediaTypeNames.Image.Jpeg);

             return NotFound("No Image Found");
            }
            catch (System.Exception)
            {
                var ResultSet =(from Photo in _AdventureWorksContext.ProductPhoto 
                            join Prod in _AdventureWorksContext.ProductProductPhoto 
                            on Photo.ProductPhotoId equals Prod.ProductPhotoId
                            where Prod.ProductId==680
                            select Photo.LargePhoto).FirstOrDefault();    
               return File(ResultSet,System.Net.Mime.MediaTypeNames.Image.Jpeg);
            }
        }
        
        [HttpGet]
         public async Task<ActionResult> GetSalesOrderHeader([FromQuery] JQXGrid JQXGrid)
         {
            var ResultSet =  await _SalesDBrepository.GetSalesOrderHeaderFromDB();
            var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
            var jsonResp = new
            {
                root = Records,
                totalrecords = ResultSet.ToList().Count()
            };
            return Json(jsonResp);
         }

        [HttpGet]
        [Route("{OrderID}")]
        public async Task<ActionResult> GetSalesOrderDetailer(string OrderID , [FromQuery] JQXGrid JQXGrid)
         {
            if(!string.IsNullOrWhiteSpace(OrderID) && !_validation.IsXSS(OrderID) && _validation.IsValidNumber(OrderID))
            {
                int ID = int.Parse(OrderID); 
                var ResultSet =  await _SalesDBrepository.GetSalesOrderDetailerFromDB(ID);
                var Records = ResultSet.ToList().Skip(JQXGrid.pagenum * JQXGrid.pagesize).Take(JQXGrid.pagesize);
                var jsonResp = new
                {
                    root = Records,
                    totalrecords = ResultSet.ToList().Count()
                };
                return Json(jsonResp);
            }
            else
            {
                return NotFound("Valid required paramenters not supplied");
            }
         }
  
   
    
    }
}

