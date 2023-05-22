namespace BookshelfWebApplication.Models
{
    public class AuthorPublication
    {
        public int Id { get; set; }
        public int PublicationId { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publication Publication { get; set; }
    }
}
