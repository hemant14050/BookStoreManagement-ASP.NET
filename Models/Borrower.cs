using System;
using System.Collections.Generic;

namespace BookStoreManagement.Models
{
    public partial class Borrower
    {
        public Borrower()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string EmailId { get; set; } = null!;
        public string? MobileNo { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
