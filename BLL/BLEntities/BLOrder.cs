using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BLEntities
{
    public class BLOrder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Statuses Status { get; set; }
        public string Country { get; set; }
        public int NumberOfPost { get; set; }
    }
}
