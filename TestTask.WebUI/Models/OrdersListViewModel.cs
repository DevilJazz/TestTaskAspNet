using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Domain.Entities;

namespace TestTask.WebUI.Models
{
    public class OrdersListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}