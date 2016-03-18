#region using

using System.Collections.Generic;

#endregion

namespace MVCUnitTesting.Models
{
    public interface Repository
    {
        List<Product> GetAllProducts();
    }
}
