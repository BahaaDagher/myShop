using myShop.Entities.Models;


namespace myShop.Entities.Repositories
{
    public interface ICategoryRepository :IGenericRepository<Category>
    {
        void Update(Category categry);
    }
}
