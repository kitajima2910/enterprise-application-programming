using Lab2WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2WebAPI.Services
{
    public interface IAccountServices
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccount(string accountCode);
        Task<Account> GetAccount(string accountCode, string pinCode);
        Task<bool> AddAccount(Account account);
        Task<bool> EditAccount(Account account);
        Task<bool> DeleteAccount(string accountCode);

    }
}
