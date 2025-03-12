using System.Linq.Expressions;


namespace myShop.Entities.Repositories
{
    public interface IGenericRepository<T> where T : class 
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>>? predicate = null , string? IncludeWord = null);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate = null, string? IncludeWord = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities); 
    }
}
