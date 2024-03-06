using System;
using System.Collections.Generic;

namespace BookStoreManagement.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? Nationality { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
