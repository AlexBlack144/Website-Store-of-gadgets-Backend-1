using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? IdGadget { get; set; }

        public virtual Gadget? IdGadgetNavigation { get; set; }
    }
}
