namespace EmployeeManagement.Repository.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Get All 
        /// </summary>
        /// <returns>List of entities</returns>
        IQueryable<T> Find();

        /// <summary>
        /// Get by expression
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list of entities</returns>
        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        /// <summary>
        /// insert entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>inserted entity</returns>
        void CreateEntity(T entity);

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>updated entity</returns>
        void UpdateEntity(T entity);

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>success or failure message</returns>
        void DeleteEntity(T entity);

        /// <summary>
        /// save changes
        /// </summary>
        void Save();
    }
}
