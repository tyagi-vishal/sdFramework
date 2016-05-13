using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Design;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Data.Objects;

namespace Allevasoft.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private readonly IDbSet<T> _dbset;
        

        public Repository(IDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
            //_objectSet = _context.GetObjectSet<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
            // _context.SaveChanges();
        }

        public virtual void AddAll(IEnumerable<T> entity)
        {
            foreach (var ent in entity)
            {
                _dbset.Add(ent);
            }
            // _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);
            //entry.State =  EntityState.Deleted;
            _dbset.Remove(entity);
            // _context.SaveChanges();
        }

        public virtual void DeleteAll(IEnumerable<T> entity)
        {
            foreach (var ent in entity)
            {
                var entry = _context.Entry(ent);
                // entry.State = EntityState.Deleted;
                _dbset.Remove(ent);
            }
            // _context.SaveChanges();
        }
        public T GetSingle(Expression<Func<T, bool>> whereCondition)
        {
            var entityResult = _context.Set<T>().Where(whereCondition).FirstOrDefault<T>();
            _dbset.Attach(entityResult);
            return entityResult;
        }
        /// <summary>
        /// To attach the entiry in db set so that it can compare previous value and current value
        /// </summary>
        /// <returns> single object of entity</returns>
        public T GetSingleOrDefault()
        {
            var entityResult = _context.Set<T>().FirstOrDefault<T>();
            _dbset.Attach(entityResult);
            return entityResult;
        }
        public virtual void Update(T entity)
        {
            var entry = _context.Entry(entity);
            //_dbset.Attach(entity);
            entry.State = System.Data.Entity.EntityState.Modified;
           // _context.SaveChanges();
        }
        public void Attach(T entity)
        {
            _dbset.Attach(entity);
        }

        public virtual bool Any()
        {
            return _dbset.Any();
        }

        //private IObjectSet<T> _objectSet;
        ///// <summary>
        ///// Gets the object set.
        ///// </summary>
        ///// <value>
        ///// The object set.
        ///// </value>
        //public IObjectSet<T> ObjectSet
        //{
        //    get
        //    {
        //        return _objectSet;
        //    }
        //}
        //public IObjectSet<T> GetObjectSet<T>()
        //   where T : class
        //{
        //    return _context...CreateObjectSet<T>();
        //}
        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        public long Count()
        {
            //return this.ObjectSet.LongCount<T>();
            return _dbset.LongCount<T>();
        }

        /// <summary>
        /// Counts the specified where condition.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <returns></returns>
        public long Count(Expression<Func<T, bool>> whereCondition)
        {
            //return this..ObjectSet.Where(whereCondition).LongCount<T>();
            return _dbset.Where(whereCondition).LongCount<T>();
        }


        /// <summary>
        /// Pageds the list.
        /// </summary>
        /// <param name="noofRecords">The noof records.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="noofPages">The noof pages.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Invalid Page number;original</exception>
        public IList<T> PagedList(out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int64 noofPages, Func<T, IComparable> orderBy)
        {
            noofRecords = Count();
            noofPages = (Int32)(noofRecords / pageSize);
            if (noofRecords % pageSize > 0)
                noofPages++;
            if (pageNo > noofPages)
                throw new System.ArgumentException("Invalid Page number", "original");
            var products = _dbset.OrderBy(orderBy).AsQueryable();
            return products.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //return this.ObjectSet.Skip(pageSize * pageNo).Take(pageSize).ToList();
            //return this.ObjectSet.OrderBy(orderBy).Skip(pageSize * pageNo).Take(pageSize).ToList();
        }
        /// <summary>
        /// Pageds the list.
        /// </summary>
        /// <param name="whereCondition">The where condition.</param>
        /// <param name="noofRecords">The noof records.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="noofPages">The noof pages.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public IList<T> PagedList(Expression<Func<T, bool>> whereCondition, out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int32 noofPages, Func<T, IComparable> orderBy)
        {
            noofRecords = Count(whereCondition);
            noofPages = (Int32)(noofRecords / pageSize);
            if (noofRecords % pageSize > 0)
                noofPages++;
            if (pageNo > noofPages)
                return null;
            if (pageNo == noofPages)
                pageNo = pageNo - 1;
            //throw new System.ArgumentException("Invalid Page number", "");
            return _dbset.Where(whereCondition).OrderBy(orderBy).Skip(pageSize * pageNo).Take(pageSize).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whereCondition">where condition</param>
        /// <param name="noofRecords">no of total records based on query</param>
        /// <param name="pageNo">current page no</param>
        /// <param name="pageSize">no of items per page</param>
        /// <param name="noofPages">total page in list</param>
        /// <param name="orderBy">order by query</param>
        /// <param name="sortOrder">asc or desc</param>
        /// <returns></returns>
        public IList<T> PagedList(Expression<Func<T, bool>> whereCondition, out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int32 noofPages, Func<T, IComparable> orderBy, string sortOrder)
        {
            noofRecords = Count(whereCondition);
            noofPages = (Int32)(noofRecords / pageSize);
            if (noofRecords % pageSize > 0)
                noofPages++;
            if (pageNo > noofPages)
                return null;
            if (pageNo == noofPages)
                pageNo = pageNo - 1;
            if (sortOrder == "asc")
                return _dbset.Where(whereCondition).OrderBy(orderBy).Skip(pageSize * pageNo).Take(pageSize).ToList();
            else
                return _dbset.Where(whereCondition).OrderByDescending(orderBy).Skip(pageSize * pageNo).Take(pageSize).ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return _dbset.Where(whereCondition).ToList<T>();
        }

        public IList<T> PagedListWithInt32(out Int64 noofRecords, Int32 pageNo, Int32 pageSize, out Int32 noofPages, Func<T, IComparable> orderBy)
        {
            noofRecords = Count();
            noofPages = (Int32)(noofRecords / pageSize);
            if (noofRecords % pageSize > 0)
                noofPages++;
            if (pageNo > noofPages)
                throw new System.ArgumentException("Invalid Page number", "original");
            var products = _dbset.OrderBy(orderBy).AsQueryable();
            return products.Skip(pageSize * pageNo).Take(pageSize).ToList();
        }
    }
}