namespace BookshelfWebApplication.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int PublicationId { get; set; }
        public Publication Publication { get; set; }

    }
}
