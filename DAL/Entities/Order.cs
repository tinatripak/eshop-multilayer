
using DAL.Enums;

namespace DAL.Entities
{
    /// <summary>
    /// Class order
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Statuses Status { get; set; }
        public string Country { get; set; }
        public int NumberOfPost { get; set; }
    }
}
