namespace Shopping.DomainModel.Models
{
   public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int Total { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
