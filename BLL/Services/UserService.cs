using AutoMapper;
using BLL.BLEntities;
using BLL.BLEntities.BLRoles;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Entities.Roles;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IWork DB { get; set; }
        public UserService(IWork db)
        {
            DB = db;
        }

        /// <summary>
        /// Exit from the account
        /// </summary>
        /// <returns>Guest account</returns>
        public BLGuest Exit()
        {
            return new BLGuest();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">The id of user</param>
        /// <returns>The looking for user</returns>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public BLUser GetUser(int? id)
        {
            if(id is null)
            {
                throw new ValidateException("The id cannot be null");
            }
            User user = DB.Users.Get(id.Value);
            if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            return new BLUser()
            {
                Basket = new MapperConfiguration(cfg => cfg.CreateMap<Product, BLProduct>()).CreateMapper().Map<IEnumerable<Product>, List<BLProduct>>(user.Basket),
                Orders = new MapperConfiguration(cfg => cfg.CreateMap<Order, BLOrder>()).CreateMapper().Map<IEnumerable<Order>, List<BLOrder>>(user.Orders),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                Money = user.Money,
                NumberofCard = user.NumberofCard,
                Pasword = user.Pasword
            };
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>IEnumerable of users</returns>
        public IEnumerable<BLUser> GetUsers()
        {
            foreach (User user in DB.Users.GetAll())
            {
                yield return GetUser(user.Id);
            }
        }

        /// <summary>
        /// Sign in to the registered account
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public BLUser SetIn(string email, string password)
        {
            User user = DB.Users.Find(f=>f.Email==email).First();
            if (user.Pasword == password) return new BLUser()
            {
                Basket = new MapperConfiguration(cfg => cfg.CreateMap<Product, BLProduct>()).CreateMapper().Map<IEnumerable<Product>, List<BLProduct>>(user.Basket),
                Orders = new MapperConfiguration(cfg => cfg.CreateMap<Order, BLOrder>()).CreateMapper().Map<IEnumerable<Order>, List<BLOrder>>(user.Orders),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                Money = user.Money,
                NumberofCard = user.NumberofCard,
                Pasword = user.Pasword
            };
            else
            {
                throw new ValidateException("Incorect password");
            }
        }

        /// <summary>
        /// Checking of using the email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true if email is used, false if the email is free</returns>
        public bool IsUsed(string email)
        {
            foreach (var user in DB.Users.GetAll())
            {
                if (user.Email == email) return true;
            }
            return false;
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User</returns>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public BLUser GetByEmail(string email)
        {
            foreach (var user in DB.Users.GetAll())
            {
                if (user.Email == email) return new BLUser()
                {
                    Basket = new MapperConfiguration(cfg => cfg.CreateMap<Product, BLProduct>()).CreateMapper().Map<IEnumerable<Product>, List<BLProduct>>(user.Basket),
                    Orders = new MapperConfiguration(cfg => cfg.CreateMap<Order, BLOrder>()).CreateMapper().Map<IEnumerable<Order>, List<BLOrder>>(user.Orders),
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    LastName = user.LastName,
                    Money = user.Money,
                    NumberofCard = user.NumberofCard,
                    Pasword = user.Pasword
                };
            }
            throw new ValidateException("The user with this email cannot be found");
        }

        /// <summary>
        /// Sign up with the card
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="card">Number of card</param>
        /// <returns></returns>
        public BLUser SetUp(string firstname, string lastname, string email, string password, long card)
        {
            Random rnd = new Random();
            RegisteredUser registered = new RegisteredUser() {
                Email = email,
                FirstName = firstname,
                Id = DB.Users.GetAll().Count() + 1,
                LastName = lastname,
                Money = rnd.Next(500, 1500),
                NumberofCard = card,
                Pasword = password
            };
            DB.Users.Create(registered);
            return GetUser(registered.Id);
        }

        /// <summary>
        /// Sign up without money and card
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public BLUser SetUp(string firstname, string lastname, string email, string password)
        {
            Random rnd = new Random();
            RegisteredUser registered = new RegisteredUser()
            {
                Email = email,
                FirstName = firstname,
                Id = DB.Users.GetAll().Count() + 1,
                LastName = lastname,
                Pasword = password
            };
            DB.Users.Create(registered);
            return GetUser(registered.Id);
        }

        /// <summary>
        /// Adds user to the list
        /// </summary>
        /// <param name="user">The user that will be added</param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void AddUser(BLUser user)
        {
            if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            DB.Users.Create(new User()
            {
                Basket = new MapperConfiguration(cfg => cfg.CreateMap<BLProduct, Product>()).CreateMapper().Map<IEnumerable<BLProduct>, List<Product>>(user.Basket),
                Orders = new MapperConfiguration(cfg => cfg.CreateMap<BLOrder, Order>()).CreateMapper().Map<IEnumerable<BLOrder>, List<Order>>(user.Orders),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                Money = user.Money,
                NumberofCard = user.NumberofCard,
                Pasword = user.Pasword
            });
        }

        /// <summary>
        /// Changes name and last of user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void ChangeUsersInfo(BLUser user, string name, string lastname)
        {
            if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            User user1 = DB.Users.Get(user.Id);
            if (user1 is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            user1.FirstName = name;
            user1.LastName = lastname;
        }

        /// <summary>
        /// Changes a password of user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void ChangeUsersPassword(BLUser user, string password)
        {
            if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            User user1 = DB.Users.Get(user.Id);
            if (user1 is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            user1.Pasword = password;
        }

        /// <summary>
        /// Changes money
        /// </summary>
        /// <param name="user"></param>
        /// <param name="money"></param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void ChangeUsersInfo(BLUser user, decimal money)
        {
            if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            User user1 = DB.Users.Get(user.Id);
            if (user1 is null)
            {
                throw new ValidateException("The user cannot be null");

            }
            user1.Money = money;
        }

        /// <summary>
        /// Changes to new user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newUser"></param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void ChangeUsersInfo(BLUser user, BLUser newUser)
        {
            if (user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            if (newUser is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            User user1 = DB.Users.Get(user.Id);
            if (user1 is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            user1 = new User()
            {
                Basket = new MapperConfiguration(cfg => cfg.CreateMap<BLProduct, Product>()).CreateMapper().Map<IEnumerable<BLProduct>, List<Product>>(user.Basket),
                Orders = new MapperConfiguration(cfg => cfg.CreateMap<BLOrder, Order>()).CreateMapper().Map<IEnumerable<BLOrder>, List<Order>>(user.Orders),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                Money = user.Money,
                NumberofCard = user.NumberofCard,
                Pasword = user.Pasword
            };
        }

        /// <summary>
        /// Changes the email of user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <exception cref="ValidateException">Thrown if parameter was null</exception>
        public void ChangeUsersEmail(BLUser user, string email)
        {
            if(user is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            User user1 = DB.Users.Get(user.Id);
            if (user1 is null)
            {
                throw new ValidateException("The user cannot be null");
            }
            user1.Email = email;
        }
    }
}
