using System.Collections.Generic;

namespace DataServiceLib.Framework
{
    public interface IDataService
    {
        IList<Category> GetCategories();
        Category GetCategory(int id);
        void CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);

        IList<Product> GetProducts(int page, int pageSize);
        Product GetProduct(int id);
        int NumberOfProducts();
    }
}