namespace EmployeeManagement.Repository
{
    using EmployeeManagement.Repository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// gets the context
        /// </summary>
        public DbContext Context { get; }

        /// <summary>
        /// Constructor for initialization
        /// </summary>
        /// <param name="context"></param>
        protected RepositoryBase(DbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// get list of all objects of entity 
        /// </summary>
        /// <returns>list of all objects of entity</returns>
        public IQueryable<T> Find()
        {
            return this.Context.Set<T>();
        }

        /// <summary>
        /// get object of entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>object of entity particular id</returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>().Where(expression);
        }

        /// <summary>
        /// insert into entity
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CreateEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Context.Set<T>().Update(entity);
        }

        /// <summary>
        /// delete object of entity
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void DeleteEntity(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
