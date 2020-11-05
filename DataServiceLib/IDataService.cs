using System.Collections.Generic;
using DataServiceLib.Moviedata;

namespace DataServiceLib.Framework
{
    public interface IDataService
    {

        IList<Users> GetUsers();

        IList<Details> GetDetails();

        IList<Actors> GetActors();


        /*Category GetCategory(int id);
        void CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);*/

        /*IList<Product> GetProducts(int page, int pageSize);
        Product GetProduct(int id);
        int NumberOfProducts();*/
    }
}