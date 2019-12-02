using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartMicroservice.ShoppingCart
{
    public interface IShoppingCartStore
    {
        ShoppingCart Get(int userId);
        void Save(ShoppingCart shoppingCart);
    }
}
