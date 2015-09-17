using System.Collections.Generic;
using System.Data.Entity;

namespace WebApplication1.Models.Interface
{
    public interface IRepositotioBase<TEntity> where TEntity :class
    {
        void Add(TEntity entidade);
        TEntity GetporId(int id);
        IEnumerable<TEntity> GetTodos();
        void Update(TEntity entidade);
        void ObjectStateManager(TEntity entidade, EntityState entityState);
        void Exeutarsql(string sql);
        void Remove(TEntity entidade);
        void Dispose();
        void Commit();
    }
}
