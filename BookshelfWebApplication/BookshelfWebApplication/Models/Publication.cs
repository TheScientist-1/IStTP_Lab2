﻿namespace BookshelfWebApplication.Models
{
    public class Publication
    {
        public Publication()
        {
            AuthorPublications = new List<AuthorPublication>();
        } 
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? ISBN { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<AuthorPublication> AuthorPublications { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
