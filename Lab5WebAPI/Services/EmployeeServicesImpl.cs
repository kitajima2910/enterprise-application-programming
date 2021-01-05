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

        public async Task<Employee> GetEmployee(string code)
        {
            return await context.GetEmployees.SingleOrDefaultAsync(m => m.Code.Equals(code));
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.GetEmployees.ToListAsync();
        }
    }
}
