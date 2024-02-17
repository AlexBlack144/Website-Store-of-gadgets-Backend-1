using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class GadgetCommentsLikeDislike
    {
        public GadgetCommentsLikeDislike()
        {
        }
        public GadgetCommentsLikeDislike( int? _IdGadget, string? _IdUser, string? _UserName, string? _Comment, bool? _IsLiked, bool? _IsDisliked, string? timeDate)
        {
            this.FkGadgetsId = _IdGadget;
            this.FkAspNetUsersId = _IdUser;
            this.UserName = _UserName;
            this.Comment = _Comment;
            this.IsLiked = _IsLiked;
            this.IsDisliked = _IsDisliked;
            this.TimeDate = timeDate;
        }

        public int Id { get; set; }
        public int? FkGadgetsId { get; set; }
        public string? FkAspNetUsersId { get; set; }
        public string? UserName { get; set; }
        public string? Comment { get; set; }
        public bool? IsLiked { get; set;}
        public bool? IsDisliked { get; set; }
        public string? TimeDate { get; set; }

        public virtual Gadget? FkGadgets { get; set; }
        public virtual IdentityUser FkAspNetUsers { get; set; }

    }
}
