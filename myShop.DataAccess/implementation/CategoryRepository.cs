using Microsoft.EntityFrameworkCore;
using myShop.Entities.Models;
using myShop.Entities.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace myShop.DataAccess.implementation
{
    public class CategoryRepository :  GenericRepository<Category> , ICategoryRepository 
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }
       
        public void Update(Category updatedCategry)
        {
            Category category = _context.Categories.FirstOrDefault( x => x.Id == updatedCategry.Id);
            if (category != null)
            {
                category.Name = updatedCategry.Name;
                category.Description = updatedCategry.Description;
                category.CreatedTime = DateTime.Now; 
            }
        }
    }
}
