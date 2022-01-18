using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent AppDBContent;
        public ShopCart(AppDBContent AppDBContent)
        {
            this.AppDBContent = AppDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

       

        public void AddToCart(Car car)
        {
            this.AppDBContent.ShopCartItem.Add(new ShopCartItem { ShopCartId = ShopCartId, car = car, price = car.price });
            AppDBContent.SaveChanges();
        }

        public void DeleteFromCart(Car car)
        {
            var ItemLine = this.AppDBContent.ShopCartItem.FirstOrDefault(item => (item.car == car)&&(item.ShopCartId==this.ShopCartId));
            if (ItemLine!=null)
            {
                this.AppDBContent.ShopCartItem.Remove(ItemLine);
                AppDBContent.SaveChanges();
            }

           /* var Item = this.listShopItems.SingleOrDefault(s => s.car.id == car.id);
            if (Item != null)
            {
                listShopItems.Remove(Item);
            }*/
        }

        public List<ShopCartItem> GetShopItems() {
            List <ShopCartItem> aaa = AppDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
            return aaa;
        }
    }
}
