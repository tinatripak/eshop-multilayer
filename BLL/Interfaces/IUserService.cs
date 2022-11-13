using BLL.BLEntities.BLRoles;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        BLUser SetUp(string firstname, string lastname, string email, string password,long card);
        BLUser SetUp(string firstname, string lastname, string email, string password);
        BLUser SetIn(string email, string password);
        void AddUser(BLUser user);
        BLUser GetUser(int? id);
        bool IsUsed(string email);
        BLUser GetByEmail(string email);
        IEnumerable<BLUser> GetUsers();
        void ChangeUsersInfo(BLUser user, string name, string lastname);
        void ChangeUsersPassword(BLUser user, string password);
        void ChangeUsersInfo(BLUser user, decimal money);
        void ChangeUsersInfo(BLUser user, BLUser newUser);
        void ChangeUsersEmail(BLUser user, string email);
        BLGuest Exit();
    }
}
