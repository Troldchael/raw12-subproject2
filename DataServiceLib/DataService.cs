using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib
{
    public class DataService : IDataService
    {
        private List<Category> _categories = new List<Category>
        {
            new Category{ Id = 1, Name = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales"},
            new Category{ Id = 2, Name = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings"},
            new Category{ Id = 3, Name = "Confections", Description = "Desserts, candies, and sweet breads"},
            new Category{ Id = 4, Name = "Dairy Products", Description = "Cheeses"},
            new Category{ Id = 5, Name = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal"},
            new Category{ Id = 6, Name = "Meat/Poultry", Description = "Prepared meats"},
            new Category{ Id = 7, Name = "Produce", Description = "Dried fruit and bean curd"},
            new Category{ Id = 8, Name = "Seafood", Description = "Seaweed and fish"}
        };

        private List<Product> _products = new List<Product>();


        public DataService()
        {
            AddProducts();
        }


        public IList<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategory(int id)
        {
            return _categories.FirstOrDefault(x => x.Id == id);
        }

        public void CreateCategory(Category category)
        {
            var maxId = _categories.Max(x => x.Id);
            category.Id = maxId + 1;
            _categories.Add(category);
        }

        public bool UpdateCategory(Category category)
        { 
            var dbCat = GetCategory(category.Id);
            if (dbCat == null)
            {
                return false;
            }
            dbCat.Name = category.Name;
            dbCat.Description = category.Description;
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var dbCat = GetCategory(id);
            if (dbCat == null)
            {
                return false;
            }
            _categories.Remove(dbCat);
            return true;
        }


        public IList<Product> GetProducts(int page, int pageSize)
        {
            return _products
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public int NumberOfProducts()
        {
            return _products.Count;
        }

        private void AddProducts()
        {
            _products.Add(new Product { Id = 1, Name = "Chai", Category = GetCategory(1) });
            _products.Add(new Product { Id = 2, Name = "Chang", Category = GetCategory(1) });
            _products.Add(new Product { Id = 3, Name = "Aniseed Syrup", Category = GetCategory(2) });
            _products.Add(new Product { Id = 4, Name = "Chef Anton's Cajun Seasoning", Category = GetCategory(2) });
            _products.Add(new Product { Id = 5, Name = "Chef Anton's Gumbo Mix", Category = GetCategory(2) });
            _products.Add(new Product { Id = 6, Name = "Grandma's Boysenberry Spread", Category = GetCategory(2) });
            _products.Add(new Product { Id = 7, Name = "Uncle Bob's Organic Dried Pears", Category = GetCategory(7) });
            _products.Add(new Product { Id = 8, Name = "Northwoods Cranberry Sauce", Category = GetCategory(2) });
            _products.Add(new Product { Id = 9, Name = "Mishi Kobe Niku", Category = GetCategory(6) });
            _products.Add(new Product { Id = 10, Name = "Ikura", Category = GetCategory(8) });
            _products.Add(new Product { Id = 11, Name = "Queso Cabrales", Category = GetCategory(4) });
            _products.Add(new Product { Id = 12, Name = "Queso Manchego La Pastora", Category = GetCategory(4) });
            _products.Add(new Product { Id = 13, Name = "Konbu", Category = GetCategory(8) });
            _products.Add(new Product { Id = 14, Name = "Tofu", Category = GetCategory(7) });
            _products.Add(new Product { Id = 15, Name = "Genen Shouyu", Category = GetCategory(2) });
            _products.Add(new Product { Id = 16, Name = "Pavlova", Category = GetCategory(3) });
            _products.Add(new Product { Id = 17, Name = "Alice Mutton", Category = GetCategory(6) });
            _products.Add(new Product { Id = 18, Name = "Carnarvon Tigers", Category = GetCategory(8) });
            _products.Add(new Product { Id = 19, Name = "Teatime Chocolate Biscuits", Category = GetCategory(3) });
            _products.Add(new Product { Id = 20, Name = "Sir Rodney's Marmalade", Category = GetCategory(3) });
            _products.Add(new Product { Id = 21, Name = "Sir Rodney's Scones", Category = GetCategory(3) });
            _products.Add(new Product { Id = 22, Name = "Gustaf's Knäckebröd", Category = GetCategory(5) });
            _products.Add(new Product { Id = 23, Name = "Tunnbröd", Category = GetCategory(5) });
            _products.Add(new Product { Id = 24, Name = "Guaraná Fantástica", Category = GetCategory(1) });
            _products.Add(new Product { Id = 25, Name = "NuNuCa Nuß-Nougat-Creme", Category = GetCategory(3) });
            _products.Add(new Product { Id = 26, Name = "Gumbär Gummibärchen", Category = GetCategory(3) });
            _products.Add(new Product { Id = 27, Name = "Schoggi Schokolade", Category = GetCategory(3) });
            _products.Add(new Product { Id = 28, Name = "Rössle Sauerkraut", Category = GetCategory(7) });
            _products.Add(new Product { Id = 29, Name = "Thüringer Rostbratwurst", Category = GetCategory(6) });
            _products.Add(new Product { Id = 30, Name = "Nord-Ost Matjeshering", Category = GetCategory(8) });
            _products.Add(new Product { Id = 31, Name = "Gorgonzola Telino", Category = GetCategory(4) });
            _products.Add(new Product { Id = 32, Name = "Mascarpone Fabioli", Category = GetCategory(4) });
            _products.Add(new Product { Id = 33, Name = "Geitost", Category = GetCategory(4) });
            _products.Add(new Product { Id = 34, Name = "Sasquatch Ale", Category = GetCategory(1) });
            _products.Add(new Product { Id = 35, Name = "Steeleye Stout", Category = GetCategory(1) });
            _products.Add(new Product { Id = 36, Name = "Inlagd Sill", Category = GetCategory(8) });
            _products.Add(new Product { Id = 37, Name = "Gravad lax", Category = GetCategory(8) });
            _products.Add(new Product { Id = 38, Name = "Côte de Blaye", Category = GetCategory(1) });
            _products.Add(new Product { Id = 39, Name = "Chartreuse verte", Category = GetCategory(1) });
            _products.Add(new Product { Id = 40, Name = "Boston Crab Meat", Category = GetCategory(8) });
            _products.Add(new Product { Id = 41, Name = "Jack's New England Clam Chowder", Category = GetCategory(8) });
            _products.Add(new Product { Id = 42, Name = "Singaporean Hokkien Fried Mee", Category = GetCategory(5) });
            _products.Add(new Product { Id = 43, Name = "Ipoh Coffee", Category = GetCategory(1) });
            _products.Add(new Product { Id = 44, Name = "Gula Malacca", Category = GetCategory(2) });
            _products.Add(new Product { Id = 45, Name = "Rogede sild", Category = GetCategory(8) });
            _products.Add(new Product { Id = 46, Name = "Spegesild", Category = GetCategory(8) });
            _products.Add(new Product { Id = 47, Name = "Zaanse koeken", Category = GetCategory(3) });
            _products.Add(new Product { Id = 48, Name = "Chocolade", Category = GetCategory(3) });
            _products.Add(new Product { Id = 49, Name = "Maxilaku", Category = GetCategory(3) });
            _products.Add(new Product { Id = 50, Name = "Valkoinen suklaa", Category = GetCategory(3) });
            _products.Add(new Product { Id = 51, Name = "Manjimup Dried Apples", Category = GetCategory(7) });
            _products.Add(new Product { Id = 52, Name = "Filo Mix", Category = GetCategory(5) });
            _products.Add(new Product { Id = 53, Name = "Perth Pasties", Category = GetCategory(6) });
            _products.Add(new Product { Id = 54, Name = "Tourtière", Category = GetCategory(6) });
            _products.Add(new Product { Id = 55, Name = "Pâté chinois", Category = GetCategory(6) });
            _products.Add(new Product { Id = 56, Name = "Gnocchi di nonna Alice", Category = GetCategory(5) });
            _products.Add(new Product { Id = 57, Name = "Ravioli Angelo", Category = GetCategory(5) });
            _products.Add(new Product { Id = 58, Name = "Escargots de Bourgogne", Category = GetCategory(8) });
            _products.Add(new Product { Id = 59, Name = "Raclette Courdavault", Category = GetCategory(4) });
            _products.Add(new Product { Id = 60, Name = "Camembert Pierrot", Category = GetCategory(4) });
            _products.Add(new Product { Id = 61, Name = "Sirop d'érable", Category = GetCategory(2) });
            _products.Add(new Product { Id = 62, Name = "Tarte au sucre", Category = GetCategory(3) });
            _products.Add(new Product { Id = 63, Name = "Vegie-spread", Category = GetCategory(2) });
            _products.Add(new Product { Id = 64, Name = "Wimmers gute Semmelknödel", Category = GetCategory(5) });
            _products.Add(new Product { Id = 65, Name = "Louisiana Fiery Hot Pepper Sauce", Category = GetCategory(2) });
            _products.Add(new Product { Id = 66, Name = "Louisiana Hot Spiced Okra", Category = GetCategory(2) });
            _products.Add(new Product { Id = 67, Name = "Laughing Lumberjack Lager", Category = GetCategory(1) });
            _products.Add(new Product { Id = 68, Name = "Scottish Longbreads", Category = GetCategory(3) });
            _products.Add(new Product { Id = 69, Name = "Gudbrandsdalsost", Category = GetCategory(4) });
            _products.Add(new Product { Id = 70, Name = "Outback Lager", Category = GetCategory(1) });
            _products.Add(new Product { Id = 71, Name = "Flotemysost", Category = GetCategory(4) });
            _products.Add(new Product { Id = 72, Name = "Mozzarella di Giovanni", Category = GetCategory(4) });
            _products.Add(new Product { Id = 73, Name = "Röd Kaviar", Category = GetCategory(8) });
            _products.Add(new Product { Id = 74, Name = "Longlife Tofu", Category = GetCategory(7) });
            _products.Add(new Product { Id = 75, Name = "Rhönbräu Klosterbier", Category = GetCategory(1) });
            _products.Add(new Product { Id = 76, Name = "Lakkalikööri", Category = GetCategory(1) });
            _products.Add(new Product { Id = 77, Name = "Original Frankfurter grüne Soße", Category = GetCategory(2) });
        }
    }
}
