using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BondIssuance.DLL.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        //void Update(TEntity entity);
        void Save(TEntity entity);
    }
}
