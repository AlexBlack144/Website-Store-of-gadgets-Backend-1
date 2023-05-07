using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Gadget
    {
        public Gadget()
        {
            Users = new HashSet<User>();
        }

        public Gadget(int _Id, string? _Image, string? _Name, string? _Model, double? _Price, int? _Quantity, int? _Sold, bool? _Status, int? _IdCategory)
        {   
            this.Id = _Id;
            this.Image = _Image;
            this.Name = _Name;
            this.Model = _Model;
            this.Price = _Price;
            this.Quantity = _Quantity; 
            this.Sold = _Sold;
            this.Status = _Status;
            this.IdCategory = _IdCategory;
        }

        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Model { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Sold { get; set; }
        public bool? Status { get; set; }
        public int? IdCategory { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
