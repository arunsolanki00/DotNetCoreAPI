using AutoMapper;
using EvinceDev.Entity;
using EvinceDev.Service.Interfaces;
using EvinceDevPracticalTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace EvinceDevPracticalTest.Controllers
{
    [Route("api/[controller]")]
    //Enable below for versioning and in EmployeeV2Controller file
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/Employee")]
    //[ApiController]
    public class EmployeeController : ControllerBase
    {
        ApplicationContext _context;
        IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper, ApplicationContext context
        )
        {
            _context = context;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Employee> listResult = _employeeService.GetAllData();

            List<EmployeeModel> employeeList = new List<EmployeeModel>();

            employeeList = _mapper.Map<List<Employee>, List<EmployeeModel>>(listResult);

            var response = new ResponseClass<List<EmployeeModel>>
            {
                IsSuccess = true,
                Data = employeeList,
                Message = "Data retrieve successfully",
                StatusCode = 200
            };
            return Ok(employeeList);
        }

        [HttpPost("GetDataWithPaging")]
        public List<EmployeeModel> Post([FromBody] PagingModel paging)
        {
            List<EmployeeModel> list = new List<EmployeeModel>();

            //string ordertype = string.Format("{0} {1}", paging.SortField, paging.SortDirection);

            //List<Employee> listResult = _context.Employees.AsQueryable().OrderBy(ordertype,
            //                    paging.SortField, paging.SortDirection).ToList();

            //if (!string.IsNullOrEmpty(paging.Search))
            //{
            //    listResult = listResult.Where(x => x.Name.Contains(paging.Search) || x.Email.Contains(paging.Search)
            //        || x.EmployeeID.Contains(paging.Search) || x.OtherPhoneNumber.Contains(paging.Search)).ToList();
            //}

            //listResult = listResult.Skip(paging.PageIndex * paging.PageSize).Take(paging.PageSize).ToList();

            List<Employee> listResult = _employeeService.GetDataWithPaging(paging.SortField, paging.SortDirection, paging.Search, paging.PageIndex, paging.PageSize);

            foreach (Employee emp in listResult)
            {
                //EmployeeModel employeeModel = new EmployeeModel()
                //{
                //    Age = emp.Age,
                //    Email = emp.Email,
                //    EmployeeID = emp.EmployeeID,
                //    Gender = emp.Gender,
                //    MobileNumber = emp.MobileNumber,
                //    Name = emp.Name,
                //    OtherPhoneNumber = emp.OtherPhoneNumber
                //};

                EmployeeModel empModel = new EmployeeModel();
                empModel = _mapper.Map<EmployeeModel>(emp);

                list.Add(empModel);
            }
            return list;
        }

        [HttpPost("Create")]
        public IActionResult Post([FromBody] EmployeeModel model)
        {
            //Employee emp = new Employee();
            //Employee employee = BindEmployeeFromModel(emp, model);
            //if (ModelState.IsValid) {
            Employee employee = _mapper.Map<Employee>(model);
            //_context.Add(employee);
            //_context.SaveChanges();
            employee = _employeeService.InsertEmployee(employee);

            var response = new ResponseClass<Employee>
            {
                IsSuccess = true,
                Data = employee,
                Message = "Data inserted successfully",
                StatusCode = 200
            };
            return Ok(response);


            //}
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            Employee employee = _mapper.Map<Employee>(model);
            _context.Add(employee);
            _context.SaveChanges();

            var response = new ResponseClass<Employee>
            {
                IsSuccess = true,
                Data = employee,
                Message = "Data inserted successfully",
                StatusCode = 200
            };
            return Ok(response);
        }

        [NonAction]
        private Employee BindEmployeeFromModel(Employee employee, EmployeeModel model)
        {
            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.EmployeeID = model.EmployeeID;
            employee.Age = model.Age;
            employee.Gender = model.Gender;
            employee.MobileNumber = model.MobileNumber;
            employee.OtherPhoneNumber = model.OtherPhoneNumber;

            return employee;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeModel model)
        {
            Employee employee = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (employee != null)
            {
                employee = _mapper.Map<Employee>(model);
                //employee.Name = model.Name;
                //employee.Email = model.Email;
                //employee.EmployeeID = model.EmployeeID;
                //employee.Age = model.Age;
                //employee.Gender = model.Gender;
                //employee.MobileNumber = model.MobileNumber;
                //employee.OtherPhoneNumber = model.OtherPhoneNumber;

                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
