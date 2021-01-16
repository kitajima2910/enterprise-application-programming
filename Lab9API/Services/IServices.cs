using Lab9DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab9API.Services
{
    public interface IServices
    {
        List<Country> GetCountries();
        Country GetCountry(int id);
        bool Update(Country country);
        bool Create(Country country);
        bool Delete(int id);
    }
}
