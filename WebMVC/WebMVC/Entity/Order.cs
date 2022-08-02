namespace WebMVC.Entity
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string status { get; set; }
        public int TotalPrice { get; set; }
        public string OrderDate { get; set; }
        public string ShippedDate { get; set; }
        public string ShipID { get; set; }
        public string Address { get; set; }
    }
}
