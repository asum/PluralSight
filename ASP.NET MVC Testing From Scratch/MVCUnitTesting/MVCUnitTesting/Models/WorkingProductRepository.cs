#region using

using System.Collections.Generic;

#endregion

namespace MVCUnitTesting.Models
{
    public class WorkingProductRepository : Repository
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product { ID = 1, Genre = "Fiction", Name = "Moby Dick", Price = 12.50m },
                new Product { ID = 2, Genre = "Fiction", Name = "War and Peace", Price = 17m },
                new Product { ID = 3, Genre = "Non-Fiction", Name = "Chemistry", Price = 35m },
                new Product { ID = 4, Genre = "Non-Fiction", Name = "Biology", Price = 35m },
                new Product { ID = 5, Genre = "Fiction", Name = "Cryptonomicon", Price = 7m },
                new Product { ID = 6, Genre = "Fiction", Name = "In Search of Lost Time", Price = 11m }
            };
        }
    }
}