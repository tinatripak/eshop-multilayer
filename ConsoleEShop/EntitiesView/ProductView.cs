using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop.EntitiesView
{
    /// <summary>
    /// presentation class for product
    /// </summary>
    public class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {Price}";
        }
    }
}
