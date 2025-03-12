using myShop.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myShop.DataAccess.implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Category = new CategoryRepository(context); 
        }

        public int Complete()
        {
            return _context.SaveChanges(); 
        }

        public void Dispose()
        {
             _context.Dispose(); 
        }
    }
}
