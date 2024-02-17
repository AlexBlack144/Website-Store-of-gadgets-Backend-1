using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int GadgetId { get; set; }
        public string? Comment { get; set; }
    }
}
