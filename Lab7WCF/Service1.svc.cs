using Lab7WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab7WCF
{
    public class Service1 : IService1
    {
        private ApplicationContext context = new ApplicationContext();

        public bool AddStaff(Staff staff)
        {
            context.Staffs.Add(staff);
            var added = context.SaveChanges();
            return added > 0;
        }

        public bool AddStore(Store store)
        {
            context.Stores.Add(store);
            var added = context.SaveChanges();
            return added > 0;
        }

        public List<Staff> GetStaffs()
        {
            return context.Staffs.ToList();
        }

        public List<Store> GetStores()
        {
            return context.Stores.ToList();
        }

        public List<StoreStaff> GetStoreStaffs()
        {
            var models = context.Staffs
                        .Join(context.Stores,
                            sf => sf.StoreId,
                            st => st.Id,
                            (sf, st) => new StoreStaff
                            {
                                Staff = sf,
                                Store = st
                            }).ToList();
            return models;
        }
    }
}
