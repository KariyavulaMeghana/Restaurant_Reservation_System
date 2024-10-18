namespace Restaurant_Reservation_System.DTO
{
    public class OrderDtoDisplay
    {
        public int OrderId
        {
            get; set;
        }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}

