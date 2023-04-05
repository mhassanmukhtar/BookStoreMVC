namespace BookStoreMVC.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid? CustomerID { get; set; }
        public Guid? BookID { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? CustomerName { get; set; }
        public string? BookName { get; set; }
    }
}
