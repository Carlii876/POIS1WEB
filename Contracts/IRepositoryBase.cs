using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POIS1WEB.Contracts
{
    public interface IRepositoryBase<R> where R : class
    {
        ICollection<R> FindAll();
        R FindbyId(int id);
        bool isExist(int id);
        bool Create(R entity);
        bool Update(R entity);
        bool Delete(R entity);
        bool Save();

    }
}
