using BLL.BLEntities;
using BLL.BLEntities.BLRoles;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(BLUser user, BLOrder order);
        BLOrder GetOrder(BLUser user, int? id);
        IEnumerable<BLOrder> GetOrders(BLUser user);
        void SetGetToOrder(BLUser user, int? id);
        void EditOrder(BLUser user, BLOrder order, string country);
        void EditOrder(BLUser user, BLOrder order, int number);
        void EditOrder(BLUser user, BLOrder order, BLOrder newOrder);
        void CancelOrder(BLUser user, int? id);
        void ChangeStatus(BLUser user, int? id, Statuses status);

    }
}
