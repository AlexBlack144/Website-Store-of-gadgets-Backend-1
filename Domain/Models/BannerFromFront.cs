using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class BannerFromFront
    {
        public BannerFromFront() { }
        public BannerFromFront(int _Id, int? _IdGadget, string? _ImgUrl)
        {
            this.Id = _Id;
            this.FkGadgetsId = _IdGadget;
            this.ImgUrl = _ImgUrl;
        }

        public int Id { get; set; }
        public int? FkGadgetsId { get; set; }
        public string? ImgUrl { get; set; }
    }
}
