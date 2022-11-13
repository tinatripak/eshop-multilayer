using DAL.Entities;
using DAL.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IWork
    {
        IRepository<Product> Products { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
