using EvinceDev.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvinceDevPracticalTest.Controllers
{
    //versioning = URL https://localhost:7277/api/v2/Employee
    //https://www.c-sharpcorner.com/article/api-versioning-in-asp-net-core-web-api/
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/employeenew")]
    public class EmployeeV1Controller : ControllerBase
    {
        ApplicationContext _context;
        public EmployeeV1Controller(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Employee> listResult = _context.Employees.ToList();

            return Ok(listResult);
        }
    }
}
