using Microsoft.AspNetCore.Mvc.Rendering;
using POIS1WEB.Contracts;
using POIS1WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Repository
{
    public class VendorRepostory : IVendorsRepository
    {
        private readonly ApplicationDbContext _db;

        public VendorRepostory(ApplicationDbContext db)
        {
            _db = db;
        }
     
        public bool Create(Vendor entity)
        {
            _db.Vendors.Add(entity);
            return Save();
        }

        public bool Delete(Vendor entity)
        {
            _db.Vendors.Remove(entity);
            return Save();
        }

        public ICollection<Vendor> FindAll()
        {
            var vendors = _db.Vendors.ToList();
            return vendors;
        }

        public Vendor FindbyId(int id)
        {
            var vendors = _db.Vendors.Find(id);
            return vendors;
        }

        public bool isExist(int id)
        {
            var exist = _db.Vendors.Any(q => q.ID == id);
            return exist;
        }

        public bool Save()
        {
            var changes =  _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Vendor entity)
        {
            _db.Vendors.Update(entity);
            return Save();
        }
    }
}
