using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositorio
{
    public class RepositotioBase<TEntity> : IDisposable, IRepositotioBase<TEntity> where TEntity : class
    {
        protected readonly SuporteContext Db = new SuporteContext();
        public void Add(TEntity entidade)
        {
            
            Db.Set<TEntity>().Add(entidade);
            Db.SaveChanges();
        }

        public TEntity GetporId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity entidade)
        {
            try
            {
                Db.Entry(entidade).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                
                throw;
            }            
            
        }

        public void ObjectStateManager(TEntity entidade, EntityState entityState)
        {
            Db.Entry(entidade).State = entityState;
        }

        public void Exeutarsql(string sql)
        {
            Db.Set<TEntity>().SqlQuery(sql);
        }

        public void Remove(TEntity entidade)
        {
            Db.Set<TEntity>().Remove(entidade);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var mensagem = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                       mensagem += string.Format("Property: {0} Error: {1}\n", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            
        }
    }
}
