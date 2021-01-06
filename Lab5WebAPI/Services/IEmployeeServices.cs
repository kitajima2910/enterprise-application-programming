using Lab5WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5WebAPI.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string code);
        Task<Employee> CheckLogin(string code, string pass);
        Task<bool> Create(Employee employee);
        Task<bool> Update(Employee employee);
        Task<bool> Delete(string code);
    }
}
