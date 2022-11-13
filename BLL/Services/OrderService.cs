using AutoMapper;
using BLL.BLEntities;
using BLL.BLEntities.BLRoles;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Entities.Roles;
using DAL.Enums;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IWork DB { get; set; }
        public OrderService(IWork db)
        {
            DB = db;
        }

        /// <summary>
        /// Return the order by user with id
        /// </summary>
        /// <param name="user">User whose order will be got</param>
        /// <param name="id">Id of order</param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public BLOrder GetOrder(BLUser user, int? id)
        {
            if (id is null)
            {
                throw new ValidateException("The Id cannot be null");
            }
            if (user is null)
            {
                throw new ValidateException("The user cannot be null");

            }
            Order order = DB.Users.Get(user.Id).Orders.Find(p=>p.Id==id);
            if (order is null)
            {
                throw new ValidateException("The order cannot be null");
            }
            return new BLOrder() { Id = order.Id, Country = order.Country, NumberOfPost = order.NumberOfPost, ProductId = order.ProductId, Status = order.Status };
            
        }

        /// <summary>
        /// Returns all orders by user
        /// </summary>
        /// <param name="user">User whose order will be got</param>
        /// <returns>An IEnumerable of orders</returns>
        /// <exception cref="ValidateException">Thrown if user was null</exception>
        public IEnumerable<BLOrder> GetOrders(BLUser user)
        {
            if(user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            User u = DB.Users.Get(user.Id);
            foreach (var order in u.Orders)
            {
                yield return new BLOrder() { Id = order.Id, Country = order.Country, NumberOfPost = order.NumberOfPost, ProductId = order.ProductId, Status = order.Status };
            } 
        }

        /// <summary>
        /// Create an order 
        /// </summary>
        /// <param name="user">User whose order will be got</param>
        /// <param name="order">Orderf that will be added to the order list</param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void MakeOrder(BLUser user, BLOrder order)
        {
            Product product = DB.Products.Get(order.ProductId);
            if (product is null)
            {
                throw new ValidateException("The product cannot be null");
            }
            else if(user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            else
            {
                Order newOrder = new Order()
                {
                    NumberOfPost = order.NumberOfPost,
                    Country = order.Country,
                    ProductId = product.Id,
                    Id = user.Orders.Count+1,
                    Status = order.Status
                };
                User u = DB.Users.Get(user.Id);
                u.Orders.Add(newOrder);
            }
        }

        /// <summary>
        /// Sets status "Get" to the order
        /// </summary>
        /// <param name="user">User whose order will be got</param>
        /// <param name="id">THe id of order</param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void SetGetToOrder(BLUser user, int? id)
        {
            if (id is null)
            {
                throw new ValidateException("The Id cannot be null");
            }
            else if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            Order orderMain = DB.Users.Get(user.Id).Orders.Find(f => f.Id == id);
            if (orderMain is null)
            {
                throw new ValidateException("The order cannot be null");
            }
            orderMain.Status = Statuses.Recieved;
        }

        /// <summary>
        /// Edits the information of order
        /// Changes country
        /// </summary>
        /// <param name="user">User whose order will be got</param>
        /// <param name="order"></param>
        /// <param name="country"></param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void EditOrder(BLUser user, BLOrder order, string country)
        {
            if (order is null)
            {
                throw new ValidateException("The order cannot be null");
            }
            else if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            Order orderMain = DB.Users.Get(user.Id).Orders.Find(f => f.Id == order.Id);
            if (orderMain is null)
            {
                throw new ValidateException("The order cannot be null");
            }
            orderMain.Country = country;
        }

        /// <summary>
        /// Edits the information of order
        /// Changes country
        /// </summary>
        /// <param name="user"></param>
        /// <param name="order"></param>
        /// <param name="number"></param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void EditOrder(BLUser user, BLOrder order, int number)
        {
            if (order is null)
            {
                throw new ValidateException("The order cannot be null");
            }
            else if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            Order orderMain = DB.Users.Get(user.Id).Orders.Find(f => f.Id == order.Id);
            if (orderMain is null)
            {
                throw new ValidateException("The odrer cannot be null");
            }
            orderMain.NumberOfPost = number;
        }

        /// <summary>
        /// Edits the information of order
        /// Changes country
        /// </summary>
        /// <param name="user"></param>
        /// <param name="order"></param>
        /// <param name="newOrder"></param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void EditOrder(BLUser user, BLOrder order, BLOrder newOrder)
        {
            if (order is null)
            {
                throw new ValidateException("The order cannot be null");
            }
            else if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            Order orderMain = DB.Users.Get(user.Id).Orders.Find(f => f.Id == order.Id);
            if (orderMain is null)
            {
                throw new ValidateException("The order cannot be null");
            }
            orderMain = new Order() { Id = orderMain.Id, Country = newOrder.Country, NumberOfPost = newOrder.NumberOfPost, ProductId = newOrder.ProductId, Status = newOrder.Status};
        }

        /// <summary>
        /// Cancel the order
        /// </summary>
        /// <param name="user">User whose order will be got</param>
        /// <param name="id">The id of order</param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void CancelOrder(BLUser user, int? id)
        {
            if (id is null)
            {
                throw new ValidateException("The id cannot be null");
            }
            if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            Order order = DB.Users.Get(user.Id).Orders.Find(f => f.Id == id);
            if (order.Status != Statuses.CanceledByAdmin && order.Status != Statuses.Recieved)
            {
                order.Status = Statuses.CanceledByUser;
            }
            else {
                throw new ValidateException("The status cannot be changed");
            }
        }

        /// <summary>
        /// Change the status of order
        /// </summary>
        /// <param name="user">User whose order will be got</param>
        /// <param name="id">The id of order</param>
        /// <param name="status">The status the will be set to the order</param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void ChangeStatus(BLUser user, int? id, Statuses status)
        {
            if (id is null)
            {
                throw new ValidateException("The id cannot be null");
            }
            if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            Order orderMain = DB.Users.Get(user.Id).Orders.Find(f => f.Id == id);
            if (orderMain is null)
            {
                throw new ValidateException("The order cannot be null");
            }
            orderMain.Status = status;
        }
    }
}
