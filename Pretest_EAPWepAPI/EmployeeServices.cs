using Microsoft.EntityFrameworkCore;
using Pretest_EAPWepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretest_EAPWepAPI
{
    public class EmployeeServices
    {
        private ApplicationContext context = new ApplicationContext();

        public async Task<List<Employee>> findAll(double? min = null, double? max = null)
        {
            var employes = await context.GetEmployees.ToListAsync();
            if(min != null && max != null)
            {
                employes = await context.GetEmployees.Where(m => m.Salary >= min && m.Salary <= max).ToListAsync();
            }

            return employes;
        }

        public async Task<Employee> findOne(string empID)
        {
            return await context.GetEmployees.SingleOrDefaultAsync(m => m.EmpID.Equals(empID));
        }

        public async Task<bool> checkLogin(string empID, string password)
        {
            var employee = await context.GetEmployees.SingleOrDefaultAsync(m => m.EmpID.Equals(empID) && m.Password.Equals(password));

            return employee != null;
        }

        public async Task<Employee> updateSalary(string empID, double salary)
        {
            var employee = await context.GetEmployees.SingleOrDefaultAsync(m => m.EmpID.Equals(empID));

            if(employee != null)
            {
                employee.Salary = salary;
                context.GetEmployees.Update(employee);
                await context.SaveChangesAsync();
                return employee;
            }

            return null;
        }
    }
}
