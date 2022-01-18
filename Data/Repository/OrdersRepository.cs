using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository: IAllOrders
    {
        private readonly AppDBContent AppDBContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDBContent AppDBContent, ShopCart shopCart)
        {
            this.AppDBContent = AppDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            AppDBContent.Order.Add(order);
            AppDBContent.SaveChanges();

            var items = shopCart.listShopItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail() { carID = el.car.id, orderID = order.id, price = el.car.price };
                AppDBContent.OrderDetail.Add(orderDetail);
            }
            AppDBContent.SaveChanges();
        }
    }
}

