using Lab5WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5WebAPI.Services
{
    public class EmployeeServicesImpl : IEmployeeServices
    {

        private ApplicationContext context;

        public EmployeeServicesImpl(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Employee> CheckLogin(string code, string pass)
        {
            return await context.GetEmployees.SingleOrDefaultAsync(m => m.Code.Equals(code) && m.Password.Equals(pass));
        }

        public async Task<bool> Create(Employee employee)
        {
            await context.GetEmployees.AddAsync(employee);
            var created = await context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> Delete(string code)
        {
            var model = await context.GetEmployees.FindAsync(code);
            context.GetEmployees.Remove(model);
            var deleted = await context.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Employee> GetEmployee(string code)
        {
            return await context.GetEmployees.SingleOrDefaultAsync(m => m.Code.Equals(code));
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.GetEmployees.ToListAsync();
        }

        public async Task<bool> Update(Employee employee)
        {
            context.GetEmployees.Update(employee);
            var updated = await context.SaveChangesAsync();
            return updated > 0;
        }
    }
}
