﻿using Dota2_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Dota2_Shop.Date.Services
{
    public class OrdersService : IOrdersServer
    {
        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
    
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Item).Where(n => n.UserId ==
            userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach( var item in items )
            {
                var orderItem = new OrderItem()
                {
                    Total = item.Total,
                    ItemId = item.Item.Id,
                    OrderId = order.Id,
                    Price = item.Item.ItemPrice,
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
