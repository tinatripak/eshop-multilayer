using AutoMapper;
using BLL.BLEntities;
using BLL.BLEntities.BLRoles;
using BLL.Interfaces;
using BLL.Services;
using ConsoleEShop.EntitiesView;
using ConsoleEShop.EntitiesView.Roles;
using DAL.Entities;
using DAL.Entities.Roles;
using DAL.Enums;
using DAL.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleEShopTest
{
    public class Tests
    {
        static IOrderService orderService;
        static IProductService productService;
        static IUserService userService;
        [SetUp]
        public void Setup()
        {
            List<ProductView> listofProduct = new List<ProductView>();
            List<UserView> listofUsers = new List<UserView>();
            listofProduct.Add(new ProductView() { Id = 1, Name = "Apple", Category = "Food", Description = "Eatable", Price = 120 });
            listofProduct.Add(new ProductView() { Id = 2, Name = "Plun", Category = "Food", Description = "Eatable", Price = 30 });
            listofProduct.Add(new ProductView() { Id = 3, Name = "Potato", Category = "Food", Description = "Eatable", Price = 15 });
            listofProduct.Add(new ProductView() { Id = 4, Name = "Carrot", Category = "Food", Description = "Eatable", Price = 20 });
            listofProduct.Add(new ProductView() { Id = 5, Name = "Cabage", Category = "Food", Description = "Eatable", Price = 40 });
            listofProduct.Add(new ProductView() { Id = 6, Name = "Grapes", Category = "Food", Description = "Eatable", Price = 63 });
            listofProduct.Add(new ProductView() { Id = 7, Name = "Cinamon", Category = "Food", Description = "Eatable", Price = 21 });
            listofProduct.Add(new ProductView() { Id = 8, Name = "Tea", Category = "Drink", Description = "Eatable", Price = 31 });
            listofProduct.Add(new ProductView() { Id = 9, Name = "Soup", Category = "Food", Description = "Eatable", Price = 150 });
            listofProduct.Add(new ProductView() { Id = 10, Name = "Coffee", Category = "Drink", Description = "Eatable", Price = 46 });
            listofProduct.Add(new ProductView() { Id = 11, Name = "Apple", Category = "Food", Description = "Fruit", Price = 120 });
            listofProduct.Add(new ProductView() { Id = 12, Name = "Plum", Category = "Food", Description = "Fruit", Price = 230 });
            listofProduct.Add(new ProductView() { Id = 13, Name = "Grapes", Category = "Food", Description = "Fruit", Price = 80 });
            listofProduct.Add(new ProductView() { Id = 14, Name = "Potato", Category = "Food", Description = "Vegetables", Price = 53 });
            listofProduct.Add(new ProductView() { Id = 15, Name = "Tomato", Category = "Food", Description = "Fruit", Price = 63 });
            listofProduct.Add(new ProductView() { Id = 16, Name = "Strawberry", Category = "Food", Description = "Fruit", Price = 54 });
            listofProduct.Add(new ProductView() { Id = 17, Name = "Cinamon", Category = "Food", Description = "Fruit", Price = 75 });
            listofProduct.Add(new ProductView() { Id = 18, Name = "Parsley", Category = "Food", Description = "Fruit", Price = 25 });
            listofProduct.Add(new ProductView() { Id = 19, Name = "Dill", Category = "Food", Description = "Fruit", Price = 54 });
            listofProduct.Add(new ProductView() { Id = 20, Name = "Tendalier", Category = "Food", Description = "Fruit", Price = 45 });
            listofProduct.Add(new ProductView() { Id = 21, Name = "Orange", Category = "Food", Description = "Fruit", Price = 74 });
            listofProduct.Add(new ProductView() { Id = 22, Name = "Plum", Category = "Food", Description = "Fruit", Price = 96 });
            listofProduct.Add(new ProductView() { Id = 23, Name = "Cake", Category = "Food", Description = "Fruit", Price = 78 });
            listofProduct.Add(new ProductView() { Id = 24, Name = "Garlic", Category = "Food", Description = "Fruit", Price = 58 });
            listofProduct.Add(new ProductView() { Id = 25, Name = "Raspberry", Category = "Food", Description = "Fruit", Price = 98 });
            listofProduct.Add(new ProductView() { Id = 26, Name = "Watermelon", Category = "Food", Description = "Fruit", Price = 78 });
            listofProduct.Add(new ProductView() { Id = 27, Name = "Melon", Category = "Food", Description = "Fruit", Price = 96 });
            listofUsers.Add(new AdminView() { Id = 1, Email = "danilkrava@ukr.net", FirstName = "Danil", LastName = "Krava", NumberofCard = 1234567890, Money = 1234, Pasword = "Krava2002" });
            listofUsers.Add(new RegisteredUserView() { Id = 2, Email = "maksim2002@gmail.com", FirstName = "Makisikm", LastName = "Genevskiy", NumberofCard = 456789765, Money = 590, Pasword = "Maks1234" });
            listofUsers.Add(new RegisteredUserView() { Id = 3, Email = "iliamak@gmail.com", FirstName = "Ilia", LastName = "Makarov", NumberofCard = 5432789754, Money = 720, Pasword = "Ilia2001" });
            DBWork dBWork = new DBWork(new MapperConfiguration(cfg => cfg.CreateMap<ProductView, Product>()).CreateMapper().Map<IEnumerable<ProductView>, List<Product>>(listofProduct),
                new MapperConfiguration(cfg => cfg.CreateMap<UserView, User>()).CreateMapper().Map<IEnumerable<UserView>, List<User>>(listofUsers));
            productService = new ProductService(dBWork);
            orderService = new OrderService(dBWork);
            userService = new UserService(dBWork);
        }

        [Test]
        public void AddUser_TestForAdmin()
        {
            BLUser admin = new BLUser() { Id = 12, Email = "qwerty@", FirstName = "Name", LastName = "LastName", NumberofCard = 1234567890, Pasword = "qwerty1234" };

            userService.AddUser(admin);
            
            Assert.AreEqual(admin.Id, userService.GetUsers().Last().Id);
        }

        [Test]
        public void AddUser_TestForRegisteredUser()
        {
            BLRegisteredUser user = new BLRegisteredUser() { Id = 12, Email = "qwerty@", FirstName = "Name", LastName = "LastName", NumberofCard = 1234567890, Pasword = "qwerty1234" };

            userService.AddUser(user);

            Assert.AreEqual(user.Id, userService.GetUsers().Last().Id);
        }

        [Test]
        public void AddToBasket_TestForRegisteredUser()
        {
            BLRegisteredUser user = new BLRegisteredUser() { Id = 12, Email = "qwerty@", FirstName = "Name", LastName = "LastName", NumberofCard = 1234567890, Pasword = "qwerty1234" };
            BLProduct product = productService.GetProduct(3);
            
            userService.AddUser(user);
            productService.AddToBasket(user, product.Id);

            Assert.AreEqual(product.Name, productService.GetBasket(user).Last().Name);
        }

        [Test]
        public void AddToBasket_TestForAdmin()
        {
            BLAdmin admin = new BLAdmin() { Id = 12, Email = "qwerty@", FirstName = "Name", LastName = "LastName", NumberofCard = 1234567890, Pasword = "qwerty1234" };
            BLProduct product = productService.GetProduct(3);

            userService.AddUser(admin);
            productService.AddToBasket(admin, product.Id);

            Assert.AreEqual(product.Name, productService.GetBasket(admin).Last().Name);
        }
        [Test]
        public void CreateOrder_TestForAdmin()
        {
            BLAdmin admin = new BLAdmin() { Id = 12, Email = "qwerty@", FirstName = "Name", LastName = "LastName", NumberofCard = 1234567890, Pasword = "qwerty1234" };
            BLOrder order = new BLOrder() { Id = 2, Country = "Ukraine", NumberOfPost = 12, ProductId = 3, Status = DAL.Enums.Statuses.New };

            userService.AddUser(admin);
            orderService.MakeOrder(admin, order);

            Assert.AreEqual(order.ProductId, orderService.GetOrders(admin).Last().ProductId);
        }
        [Test]
        public void SetUp_Test()
        {
            object obj = userService.SetUp("Name", "LastName", "qwerty@", "qwerty1234");

            Assert.That(obj is BLUser);
        }
        [Test]
        public void SetIn_Test()
        {
           object obj =  userService.SetIn("danilkrava@ukr.net", "Krava2002");

            Assert.That((obj as BLUser).Email == "danilkrava@ukr.net");
        }
        [Test]
        public void CancelOrder_Test()
        {
            BLAdmin admin = new BLAdmin() { Id = 12, Email = "qwerty@", FirstName = "Name", LastName = "LastName", NumberofCard = 1234567890, Pasword = "qwerty1234" };
            BLOrder order = new BLOrder() { Id = 2, Country = "Ukraine", NumberOfPost = 12, ProductId = 3, Status = DAL.Enums.Statuses.New };

            userService.AddUser(admin);
            orderService.MakeOrder(admin, order);
            orderService.CancelOrder(admin, orderService.GetOrders(admin).Last().Id);

            Assert.That(orderService.GetOrders(admin).Last().Status == Statuses.CanceledByUser);
        }
        [Test]
        public void ChangeEmail_Test()
        {
            userService.ChangeUsersEmail(userService.GetUser(2),"qwerty@ukr.net");

            Assert.That(userService.GetUser(2).Email == "qwerty@ukr.net");
        }
        [Test]
        public void ChangePassword_Test()
        {
            userService.ChangeUsersPassword(userService.GetUser(2), "12345678");

            Assert.That(userService.GetUser(2).Pasword == "12345678");
        }
        [Test]
        public void ChangeFullName_Test()
        {
            userService.ChangeUsersInfo(userService.GetUser(2),"Mark", "Krava");

            Assert.That(userService.GetUser(2).FirstName == "Mark" && userService.GetUser(2).LastName == "Krava");
        }
        [Test]
        public void SetGetToOrder_Test()
        {
            BLAdmin admin = new BLAdmin() { Id = 12, Email = "qwerty@", FirstName = "Name", LastName = "LastName", NumberofCard = 1234567890, Pasword = "qwerty1234" };
            BLOrder order = new BLOrder() { Id = 2, Country = "Ukraine", NumberOfPost = 12, ProductId = 3, Status = DAL.Enums.Statuses.New };

            userService.AddUser(admin);
            orderService.MakeOrder(admin, order);
            orderService.SetGetToOrder(admin, orderService.GetOrders(admin).Last().Id);

            Assert.That(orderService.GetOrders(admin).Last().Status == Statuses.Recieved);
        }

        [TestCase(Statuses.CanceledByAdmin)]
        [TestCase(Statuses.Sent)]
        [TestCase(Statuses.Ended)]
        public void ChangeStatus_Test(Statuses status)
        {
            BLAdmin admin = new BLAdmin() { Id = 12, Email = "qwerty@", FirstName = "Name", LastName = "LastName", NumberofCard = 1234567890, Pasword = "qwerty1234" };
            BLOrder order = new BLOrder() { Id = 2, Country = "Ukraine", NumberOfPost = 12, ProductId = 3, Status = DAL.Enums.Statuses.New };

            userService.AddUser(admin);
            orderService.MakeOrder(admin, order);
            orderService.ChangeStatus(admin, orderService.GetOrders(admin).Last().Id, status);

            Assert.That(orderService.GetOrders(admin).Last().Status == status);
        }

        [Test]
        public void ChangeProduct_Test()
        {
            BLAdmin admin = new BLAdmin() { Id = 12, Email = "qwerty@", FirstName = "Name", LastName = "LastName", NumberofCard = 1234567890, Pasword = "qwerty1234" };
            BLProduct product = productService.GetProduct(3);

            userService.AddUser(admin);
            productService.EditProduct(product.Id, 123);

            Assert.That(productService.GetProduct(3).Price == 123);
        }
    }
}