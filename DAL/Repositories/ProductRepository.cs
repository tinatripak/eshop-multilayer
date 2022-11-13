using DAL.DataBase;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    /// <summary>
    /// Implemetation for product servise
    /// </summary>
    public class ProductRepository : IRepository<Product>
    {
        private Context DB;
        /// <summary>
        /// Conection with DB
        /// </summary>
        /// <param name="db"></param>
        public ProductRepository(Context db)
        {
            DB = db;
        }

        /// <summary>
        /// Retrives ienumerable of product
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<Product> Find(Func<Product, bool> predicate) => DB.Products.Where(predicate).ToList();

        /// <summary>
        /// get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Get(int id) => DB.Products.Find(f=>f.Id == id);

        /// <summary>
        /// get all products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAll() => DB.Products;

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="item"></param>
        public void Create(Product item) => DB.Products.Add(item);

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="item"></param>
        public void Delete(Product item) => DB.Products.Remove(item);

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="item"></param>
        public void Update(Product item)
        {
            Product product = Get(item.Id);
            product = item;
        }

        /// <summary>
        /// Delete a product by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Product product = Get(id);
            if (product != null)
                DB.Products.Remove(product);
            else { 
                //throw Exception
            }
        }
    }
}
