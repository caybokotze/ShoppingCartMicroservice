using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCartMicroservice.ShoppingCart;

namespace ShoppingCartMicroservice.Product
{
    public interface IProductCatalogueClient
    {
        Task<IEnumerable<ShoppingCartItem>> 
            GetShoppingCartItems(int[] productCatalogueIds);
    }
}
