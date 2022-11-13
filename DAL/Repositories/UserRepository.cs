using DAL.DataBase;
using DAL.Entities;
using DAL.Entities.Roles;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class UserRepository : IRepository<User>
    {
        private Context DB;
        public UserRepository(Context db)
        {
            DB = db;
        }

        /// <summary>
        /// Retrives ienumerable of user
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<User> Find(Func<User, bool> predicate) => DB.Users.Where(predicate).ToList();

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Get(int id) => DB.Users.Find(f => f.Id == id);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll() => DB.Users;

        /// <summary>
        /// Create an user
        /// </summary>
        /// <param name="item"></param>
        public void Create(User item) => DB.Users.Add(item);

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="item"></param>
        public void Delete(User item) => DB.Users.Remove(item);

        /// <summary>
        /// Update the user by id
        /// </summary>
        /// <param name="item"></param>
        public void Update(User item)
        {
            User user = Get(item.Id);
            user = item;
        }
        
        /// <summary>
        /// Delete an user by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            User user = Get(id);
            if (user != null)
                DB.Users.Remove(user);
            else
            {
                //throw Exception
            }
        }
    }
}
