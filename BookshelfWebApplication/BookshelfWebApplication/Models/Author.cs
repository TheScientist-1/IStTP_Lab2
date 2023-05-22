namespace BookshelfWebApplication.Models
{
    public class Author
    {
        public Author()
        {
            AuthorPublications = new List<AuthorPublication>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Information {get; set; }
        public virtual ICollection<AuthorPublication> AuthorPublications { get;}
    }
}
