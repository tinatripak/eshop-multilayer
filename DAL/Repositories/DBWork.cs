using DAL.DataBase;
using DAL.Entities;
using DAL.Entities.Roles;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    /// <summary>
    /// Class for work with DataBase
    /// </summary>
    public class DBWork : IWork
    {
        private Context DB;
        private ProductRepository productRepository;
        private UserRepository userRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="products"></param>
        /// <param name="users"></param>
        public DBWork(List<Product> products, List<User> users)
        {
            DB = new Context(products,users);
        }
        /// <summary>
        /// Get Products
        /// </summary>
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository is null)
                    productRepository = new ProductRepository(DB);
                return productRepository;
            }
        }

        /// <summary>
        /// Get Users
        /// </summary>
        public IRepository<User> Users
        {
            get
            {
                if (userRepository is null)
                    userRepository = new UserRepository(DB);
                return userRepository;
            }
        }

        /// <summary>
        /// Save DataBase
        /// </summary>
        public void Save()
        {
            //Save for Data Base
        }
    }
}
