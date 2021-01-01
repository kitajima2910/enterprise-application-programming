using Lab2WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2WebAPI.Services
{
    public class Services : IServices<Account>
    {
        public Task<bool> Create(Account t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> FindAll(object[] args)
        {
            throw new NotImplementedException();
        }

        public Task<Account> FindByArgs(object[] args)
        {
            throw new NotImplementedException();
        }

        public Task<Account> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> FindByStr(string str)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, Account t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id, Account t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Account t)
        {
            throw new NotImplementedException();
        }
    }
}
