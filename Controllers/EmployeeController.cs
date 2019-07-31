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
    public class EmployeeController : Controller
    {
        private readonly IDBRepository _DBRepository;
        private readonly AdventureWorksContext _AdventureWorksContext;
        private readonly ILogger _logger;
        private readonly IValidation _validation;

        public EmployeeController(AdventureWorksContext adventureWorksContext,
                                    ILogger<EmployeeController> logger,
                                    IValidation Validation,
                                    IDBRepository DBRepository)
        {
            _AdventureWorksContext = adventureWorksContext;
            _logger = logger;
            _validation = Validation;
            _DBRepository = DBRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<object>> GetEmployeeDetails()
        {
            List<object> employeeViews = new List<object>();

            try
            {
                employeeViews = await _DBRepository.GetEmployee();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return employeeViews;
        }


        [HttpGet]
        [Route("{empid}")]
        public async Task<object> GetEmployeeDetails(int empid)
        {
            object employee = new object();
            try
            {
                employee = await _DBRepository.GetEmployee(empid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return employee;
        }
    
    
    }
}
