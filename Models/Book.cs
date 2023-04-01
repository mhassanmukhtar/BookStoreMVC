namespace BookStoreMVC.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        public int? quantity { get; set; }
        public bool? IsBooked { get; set; }
    }
}
