using Microsoft.AspNetCore.Mvc.Rendering;
using POIS1WEB.Contracts;
using POIS1WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Repository
{
    public class InvoiceRepository : I_Invoice
    {
        private readonly ApplicationDbContext _db;

        public InvoiceRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Invoice entity)
        {
            _db.Invoices.Add(entity);
            return Save();
        }

        public bool Delete(Invoice entity)
        {
            _db.Invoices.Remove(entity);
            return Save();
        }

        public ICollection<Invoice> FindAll()
        {
           
                var Invoices = _db.Invoices.ToList();
                return Invoices;
            
           
        }

        public Invoice FindbyId(int id)
        {
            var Invoices = _db.Invoices.Find(id);
            return Invoices;
        }

        public bool isExist(int id)
        {
            var exist = _db.Invoices.Any(q => q.ID == id);
            return exist;
        }
        
        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Invoice entity)
        {
            _db.Invoices.Update(entity);
            return Save();
        }
    }
}
