using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF2.Models;

namespace WCF2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IRemoteEmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IRemoteEmployeeService.svc or IRemoteEmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class IRemoteEmployeeService : IIRemoteEmployeeService
    {

        private ApplicationContext context = new ApplicationContext();

        public Employee GetEmployee(string id)
        {
            return context.GetEmployees.Find(int.Parse(id));
        }

        public List<Employee> GetEmployeesList()
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
