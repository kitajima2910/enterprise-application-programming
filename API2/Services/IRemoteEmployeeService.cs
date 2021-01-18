using API2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Services
{
    public interface IRemoteEmployeeService
    {
        bool PostEmployee(Employee employee);
        List<Employee> GetEmployeeList();
        Employee GetEmployee(int employeeId);
        bool PutEmployee(Employee employee);
    }
}
