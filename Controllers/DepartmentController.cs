using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksAPI.Helpers;
using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdventureWorksAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    public class DepartmentController : Controller
    {

        private readonly AdventureWorksContext _AdventureWorksContext;
        private readonly ILogger _logger;
        private readonly IValidation _validation;

        public DepartmentController(AdventureWorksContext adventureWorksContext,
                                    ILogger<DepartmentController> logger,
                                    IValidation Validation)
        {
            _AdventureWorksContext = adventureWorksContext;
            _logger = logger;
            _validation = Validation;
        }

        [HttpGet]
        public IEnumerable<object> GetDepartmentDetails()
        {
                return _AdventureWorksContext.Department.Select(d=>new {
                   d.DepartmentId,
                   d.Name,
                   d.GroupName,
                   d.ModifiedDate,
                }).ToList();
        }

        [HttpGet]
        [Route("{deptid}")]
        public ActionResult<Department> GetDepartmentDetails(string deptid)
        {
            Department department=null;
            if (!String.IsNullOrWhiteSpace(deptid) && ! _validation.IsXSS(deptid))
            {
                department= _AdventureWorksContext.Department.AsQueryable()
                                                .Where(d => d.DepartmentId == Convert.ToInt32(deptid)).Select(d => d).SingleOrDefault();
            }
            else
            {
                return NotFound(string.Format("No Records found for:{0}",deptid));
            }
            return department;
        }

        [HttpGet]
        public IEnumerable<string> GetDepartmentNames()
        {
            return _AdventureWorksContext.Department.Select(d =>d.Name );
        }
    }
}
