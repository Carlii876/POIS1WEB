using POIS1WEB.Contracts;
using POIS1WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Repository
{
    public class ItemsRepositry : I_ItemsRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemsRepositry(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Items entity)
        {
            var items = _db.Items.Add(entity);
            return Save();
        }

        public bool Delete(Items entity)
        {
            var items = _db.Items.Remove(entity);
            return Save();
        }

        public ICollection<Items> FindAll()
        {
            var items = _db.Items.ToList();
            return items;
        }

        public Items FindbyId(int id)
        {
           var items = _db.Items.Find(id);
            return items;
        }

        public bool isExist(int id)
        {
            var exist = _db.Items.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Items entity)
        {
            _db.Items.Update(entity);
            return Save();
        }
    }
}
