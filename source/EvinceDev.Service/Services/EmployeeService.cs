using EvinceDev.Entity;
using EvinceDev.Service.Interfaces;
using System.Net.NetworkInformation;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace EvinceDev.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        ApplicationContext _context;

        public EmployeeService(ApplicationContext context) {
            _context = context;
        }
        public List<Employee> GetAllData()
        {
            List<Employee> listResult = _context.Employees.ToList();
            return listResult;
        }

        public List<Employee> GetDataWithPaging(string SortField, string SortDirection,string Search,int PageIndex,int PageSize)
        {

            string ordertype = string.Format("{0} {1}", SortField, SortDirection);

            List<Employee> listResult = _context.Employees.AsQueryable().OrderBy(ordertype,
                                SortField, SortDirection).ToList();

            if (!string.IsNullOrEmpty(Search))
            {
                listResult = listResult.Where(x => x.Name.Contains(Search) || x.Email.Contains(Search)
                    || x.EmployeeID.Contains(Search) || x.OtherPhoneNumber.Contains(Search)).ToList();
            }

            listResult = listResult.Skip(PageIndex * PageSize).Take(PageSize).ToList();
            return listResult;
        }

        public Employee InsertEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return employee;
            //List<Employee> listResult = _context.Employees.ToList();
            //return listResult;
        }
    }
}