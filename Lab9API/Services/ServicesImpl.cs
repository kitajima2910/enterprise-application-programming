using Lab9API.Repositories;
using Lab9DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab9API.Services
{
    public class ServicesImpl : IServices
    {

        private ApplicationContext context = new ApplicationContext();

        public bool Create(Country country)
        {
            context.GetCountries.Add(country);
            var created = context.SaveChanges();
            return created > 0;
        }

        public bool Delete(int id)
        {
            var model = context.GetCountries.Find(id);
            context.GetCountries.Remove(model);
            var deleted = context.SaveChanges();
            return deleted > 0;
        }

        public List<Country> GetCountries()
        {
            return context.GetCountries.ToList();
        }

        public Country GetCountry(int id) => context.GetCountries.SingleOrDefault(m => m.Id == id);

        public bool Update(Country country)
        {
            context.GetCountries.Update(country);
            var updated = context.SaveChanges();
            return updated > 0;
        }
    }
}
