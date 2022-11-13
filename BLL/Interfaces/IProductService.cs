using BLL.BLEntities;
using BLL.BLEntities.BLRoles;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(BLProduct product);
        BLProduct GetProduct( int? id);
        IEnumerable<BLProduct> GetProducts();
        IEnumerable<BLProduct> GetBasket(BLUser user);
        void AddToBasket(BLUser user, int? id);
        void DeleteFromBasket(BLUser user, int? id);
        void EditProduct(int? id, string name);
        void EditProduct(int? id, decimal price);
        void EditProduct(int? id, BLProduct newPro);
        void DeleteProduct(BLProduct product);
        void DeleteProduct(int? id);
    }
}
