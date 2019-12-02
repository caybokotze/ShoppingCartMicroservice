using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;
using ShoppingCartMicroservice.EventFeed;
using ShoppingCartMicroservice.Product;
using ShoppingCartMicroservice.ShoppingCart;

//
namespace ShoppingCartMicroservice
{
    public class ShoppingCartModule : NancyModule
    {
        public ShoppingCartModule(IShoppingCartStore shoppingCartStore, 
            IProductCatalogueClient productCatalogClient, 
            IEventStore eventStore) : base ("/shoppingcart")
        {
            Get("/{userid:int}", parameters =>
            {
                var userId = (int) parameters.userid;
                return shoppingCartStore.Get(userId);
            });

            Post("/{userid:int}/items", async (parameters, _) =>
            {
                var productCatalogIds = this.Bind<int[]>();
                var userId = (int) parameters.userid;
                //
                var shoppingCart = shoppingCartStore.Get(userId);
                var shoppingCartItems =
                    await productCatalogClient.GetShoppingCartItems(productCatalogIds)
                        .ConfigureAwait(false);
                shoppingCart.AddItems(shoppingCartItems, eventStore);
                shoppingCartStore.Save(shoppingCart);
                return shoppingCart;
            });

            Delete("/{userid:int}/items", parameters =>
            {
                var productCatalogueIds = this.Bind<int[]>();
                var userId = (int) parameters.userid;
                var shoppingCart = shoppingCartStore.Get(userId);
                shoppingCart.RemoveItems(productCatalogueIds, eventStore);
                shoppingCartStore.Save(shoppingCart);
                return shoppingCart;
            });
            

        }
    }
}
