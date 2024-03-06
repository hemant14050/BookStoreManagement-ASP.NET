using System;
using System.Collections.Generic;

namespace BookStoreManagement.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? OfficeLocation { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
