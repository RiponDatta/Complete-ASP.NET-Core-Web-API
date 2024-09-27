using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) => this.repositoryContext = repositoryContext;

        public T Create(T entity)
        {
            repositoryContext.Set<T>().Add(entity);
            
            //repositoryContext.SaveChanges();
            
            return entity;
        }

        public void Update(T entity) => repositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => repositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll() => repositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => repositoryContext.Set<T>().Where(expression);
    }
}
