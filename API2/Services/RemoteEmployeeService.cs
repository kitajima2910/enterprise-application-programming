using API2.Models;
using API2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Services
{
    public class RemoteEmployeeService : IRemoteEmployeeService
    {

        private ApplicationContext context = new ApplicationContext();

        public Employee GetEmployee(int employeeId)
        {
            return context.GetEmployees.Find(employeeId);
        }

        public List<Employee> GetEmployeeList()
        {
            return context.GetEmployees.ToList();
        }

        public bool PostEmployee(Employee employee)
        {
            context.GetEmployees.Add(employee);
            var posted = context.SaveChanges();
            return posted > 0;
        }

        public bool PutEmployee(Employee employee)
        {
            context.GetEmployees.Update(employee);
            var puted = context.SaveChanges();
            return puted > 0;
        }
    }
}
