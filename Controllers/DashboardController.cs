using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksAPI.Helpers;
using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksAPI.DB;
using System.Net;
using System.Net.Http;

namespace AdventureWorksAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly IDashboardDBRepository _DashboardDBRepository;
        private readonly AdventureWorksContext _AdventureWorksContext;
        private readonly ILogger _logger;
        private readonly IValidation _validation;

        public DashboardController(AdventureWorksContext adventureWorksContext,
                                    ILogger<DashboardController> logger,
                                    IValidation Validation,
                                    IDashboardDBRepository DashboardDBRepository)
        {
            _AdventureWorksContext = adventureWorksContext;
            _logger = logger;
            _validation = Validation;
            _DashboardDBRepository = DashboardDBRepository;
        }

        [HttpGet]
        public async Task<double> GetTotalSalesForTheYear()
        {
            return await _DashboardDBRepository.GetTotalSalesForTheYearFromDB();
        }

        [HttpGet]
        public async Task<int> GetTotalCustomerCount()
        {
            return await _DashboardDBRepository.GetTotalCustomersCountFromDB();
        }
        
        [HttpGet]
        public async Task<IEnumerable<object>> GetTerritorySalesReport()
        {
            return await _DashboardDBRepository.GetTerritorySalesReportFromDB();
        }

        [HttpGet]
        [Route("{Year}")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductSalesReport(string Year)
        {
            if(!String.IsNullOrWhiteSpace(Year) && ! _validation.IsXSS(Year) && _validation.IsValidYear(Year))
            {
                var result = await _DashboardDBRepository.GetProductSalesReportFromDB(Year);
                return result.ToList();
            }
            else    
            {   
                return NotFound("Valid required paramenters not supplied"); 
             }
        }

         [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetPendingShipmentDetails()
        {
            var result = await _DashboardDBRepository.GetPendingShipmentDetailsFromDB();
            return result.ToList();
        }
    }
}
