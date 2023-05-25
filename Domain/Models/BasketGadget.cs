using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BasketGadget
    {

        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Sold { get; set; }
        public bool? Status { get; set; }
        public int? IdCategory { get; set; }
        public int? Count { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }

    }
}
