using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Enums
{
    /// <summary>
    /// Statuses enum for status
    /// </summary>
    public enum Statuses
    {
        New,
        CanceledByAdmin,
        CanceledByUser,
        GetMoney,
        Sent,
        Recieved,
        Ended
    }
}
