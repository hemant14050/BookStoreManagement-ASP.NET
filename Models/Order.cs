using System;
using System.Collections.Generic;

namespace BookStoreManagement.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int BorrowerId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Borrower Borrower { get; set; } = null!;
    }
}
