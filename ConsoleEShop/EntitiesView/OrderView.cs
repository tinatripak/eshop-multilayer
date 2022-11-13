using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop.EntitiesView
{
    /// <summary>
    /// presentation class for order
    /// </summary>
    public class OrderView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Statuses Status { get; set; }
        public string Country { get; set; }
        public int NumberOfPost { get; set; }
    }
}
