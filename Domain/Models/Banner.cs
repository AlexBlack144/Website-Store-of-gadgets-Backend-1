using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class Banner
    {
        public Banner()
        {
        }
        public Banner(int _Id, int? _IdGadget, string? _ImgUrl)
        {
            this.Id = _Id;
            this.FkGadgetsId = _IdGadget;
            this.ImgUrl = _ImgUrl;
        }

        public int Id { get; set; }
        public int? FkGadgetsId { get; set; }
        public string? ImgUrl { get; set; }

        public virtual Gadget? FkGadgets { get; set; }

    }
}
