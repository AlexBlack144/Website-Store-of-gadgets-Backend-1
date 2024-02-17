using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class LikeOrDis
    {
        public int GadgetId { get; set; }
        public bool? Like { get; set; }
        public bool? Dis { get; set; }
    }
}
