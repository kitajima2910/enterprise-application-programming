using Lab8WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab8WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private EmployeeContext context = new EmployeeContext();

        public Employee GetEmployee(string code)
        {
            return context.GetEmployees.SingleOrDefault(m => m.Code.Equals(code));
        }

        public IEnumerable<Employee> GetEmployees()
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
