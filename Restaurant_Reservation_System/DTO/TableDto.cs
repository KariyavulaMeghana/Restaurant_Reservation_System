namespace Restaurant_Reservation_System.DTO
{
    public class TableDto
    {
        public int TableId { get; internal set; }
        public int NoOfTables { get; set; }
        public bool IsBooked { get; set; }
        public int RestaurantId { get; set; }
    }
}

