using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Gadgets = new HashSet<Gadget>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Gadget> Gadgets { get; set; }
    }
}
