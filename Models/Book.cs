using System;
using System.Collections.Generic;

namespace BookStoreManagement.Models
{
    public partial class Book
    {
        public Book()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public DateTime? PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public int? PublisherId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
