using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain.Abstract;
using TestTask.Domain.Entities;

namespace TestTask.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders => context.Orders;

        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.Find(order.OrderId);
                if (dbEntry != null)
                {
                    dbEntry.Number = order.Number;
                    dbEntry.CreationDate = order.CreationDate;
                    dbEntry.ShippingDate = order.ShippingDate;
                    dbEntry.Manager = order.Manager;
                    dbEntry.Note = order.Note;
                }
            }
            context.SaveChanges();
        }
    }
}
