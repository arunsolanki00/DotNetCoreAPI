using EvinceDev.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvinceDev.Service.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllData();

        List<Employee> GetDataWithPaging(string SortField, string SortDirection, string Search, int PageIndex, int PageSize);

        Employee InsertEmployee(Employee employee);
    }
}
