using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorksAPI.Helpers;
using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksAPI.DB;


[Route("api/[controller]/[action]")]
public class HRController : Controller
{

    private readonly IHRDBRepository _DBRepository;
    private readonly AdventureWorksContext _AdventureWorksContext;
    private readonly ILogger _logger;
    private readonly IValidation _validation;

    public HRController(AdventureWorksContext adventureWorksContext,
                                ILogger<HRController> logger,
                                IValidation Validation,
                                IHRDBRepository DBRepository)
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

    [HttpGet]
    public IEnumerable<object> GetDepartmentDetails()
    {
        return _AdventureWorksContext.Department.Select(d => new
        {
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
        Department department = null;
        if (!String.IsNullOrWhiteSpace(deptid) && !_validation.IsXSS(deptid))
        {
            department = _AdventureWorksContext.Department.AsQueryable()
                                            .Where(d => d.DepartmentId == Convert.ToInt32(deptid)).Select(d => d).SingleOrDefault();
        }
        else
        {
            return NotFound(string.Format("No Records found for:{0}", deptid));
        }
        return department;
    }

    [HttpGet]
    public IEnumerable<string> GetDepartmentNames()
    {
        return _AdventureWorksContext.Department.Select(d => d.Name);
    }

}