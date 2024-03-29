﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartMicroservice.ShoppingCart
{
    public class ShoppingCartStore : IShoppingCartStore
    {
        private static readonly Dictionary<int, ShoppingCart> database = new Dictionary<int, ShoppingCart>();
        public ShoppingCart Get(int userId)
        {
            if (!database.ContainsKey(userId))
                database[userId] = new ShoppingCart(userId);
            return database[userId];
        }

        public void Save(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}
