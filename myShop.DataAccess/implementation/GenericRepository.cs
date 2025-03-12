using Microsoft.EntityFrameworkCore;
using myShop.Entities.Repositories;
using System.Linq.Expressions;
namespace myShop.DataAccess.implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); 
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity); 
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate, string? IncludeWord)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate); 
            }
            if (IncludeWord != null)
            {
                // _context.Products.Include("Category,Logos,Users") ; 
                foreach(var item in IncludeWord.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item); 
                }
            }
            return query.ToList(); 
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? predicate, string? IncludeWord)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (IncludeWord != null)
            {
                // _context.Products.Include("Category,Logos,Users") ; 
                foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
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
