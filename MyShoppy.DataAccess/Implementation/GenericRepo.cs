using Microsoft.EntityFrameworkCore;
using MyShoppy.DataAccess.Data;
using MyShoppy.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppy.DataAccess.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationContext _context; // to access the database
        private DbSet<T> _dbSet; // to access the table Models

        public GenericRepo(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            // Categories.Add(category);
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null, string? IncludeWord = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (IncludeWord != null)
            {
                // _context.Products.Include("Category,Logos,Users");
                foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }

        public T GetFirstorDefault(Expression<Func<T, bool>> predicate = null, string? IncludeWord = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (IncludeWord != null)
            {
                // _context.Products.Include("Category,Logos,Users");
                foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }



        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
