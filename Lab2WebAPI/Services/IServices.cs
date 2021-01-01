using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2WebAPI.Services
{
    public interface IServices<T>
    {

        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindAll(object[] args);


        Task<T> FindById(int id);
        Task<T> FindById(string id);
        Task<T> FindByStr(string str);
        Task<T> FindByArgs(object[] args);

        Task<bool> Update(int id, T t);
        Task<bool> Update(string id, T t);
        Task<bool> Update(T t);

        Task<bool> Create(T t);

        Task<bool> Delete(int id);
        Task<bool> Delete(string id);

    }
}
