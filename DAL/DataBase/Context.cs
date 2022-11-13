using DAL.Entities;
using DAL.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataBase
{
    /// <summary>
    /// DBContext
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Products
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();
        /// <summary>
        /// Users
        /// </summary>
        public List<User> Users { get; set; } = new List<User>();
        static Context()
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="products"></param>
        /// <param name="users"></param>
        public Context(List<Product> products,List<User> users)
        {
            Products = products;
            Users = users;
        }      
    }
}
