namespace Restaurant_Reservation_System.Models
{
    public class CustomException:Exception
    {
        public CustomException():base(){}
        public CustomException(string message):base(message)
        {
            
        }
    }
}
