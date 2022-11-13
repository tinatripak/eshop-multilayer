using DAL.DataBase;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop.EntitiesView.Roles
{
    /// <summary>
    /// presentation class for user
    /// </summary>
    public class UserView 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public long NumberofCard { get; set; }
        public decimal Money { get; set; }
        public List<OrderView> Orders { get; set; } = new List<OrderView>();
        public List<ProductView> Basket { get; set; } = new List<ProductView>();
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email} {Money}$";
        }
    }
}
