using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Domain.Models
{
    public partial class Purchase
    {
        public Purchase() { }

        public Purchase(string _FkAspNetUsersId, int _FkGadgetsId, int? _Count, double? _TotalPrice, string _Date)
        {
            this.FkAspNetUsersId = _FkAspNetUsersId;
            this.FkGadgetsId = _FkGadgetsId;
            this.Count = _Count;
            this.TotalPrice = _TotalPrice;
            this.Date = _Date;
        }
        public int Id { get; set; }
        public string FkAspNetUsersId { get; set; } = null!;
        public int FkGadgetsId { get; set; }
        public int? Count { get; set; }
        public double? TotalPrice { get; set; }
        public string Date { get; set; } = null!;

        public virtual IdentityUser FkAspNetUsers { get; set; } = null!;
        public virtual Gadget? FkGadgets { get; set; } = null!;

    }
}
