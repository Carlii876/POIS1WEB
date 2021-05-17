using Microsoft.AspNetCore.Mvc.Rendering;
using POIS1WEB.Contracts;
using POIS1WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public PurchaseOrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(PurchaseOrder entity)
        {
            _db.PurchaseOrders.Add(entity);
            return Save();
           
        }

        public bool Delete(PurchaseOrder entity)
        {
            _db.PurchaseOrders.Remove(entity);
            return Save();
        }

        public ICollection<PurchaseOrder> FindAll()
        {
            var purchaseorder = _db.PurchaseOrders.ToList();
            return purchaseorder;
        }

        public PurchaseOrder FindbyId(int id)
        {
            var purchaseorder = _db.PurchaseOrders.Find(id);
            return purchaseorder;
        }

        public bool isExist(int id)
        {
            var exist = _db.PurchaseOrders.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(PurchaseOrder entity)
        {
            _db.PurchaseOrders.Update(entity);
            return Save();
        }
    }
}
