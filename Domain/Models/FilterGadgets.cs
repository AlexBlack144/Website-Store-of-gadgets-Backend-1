using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FilterGadgets
    {
        public string[]? nameModels { get; set; }
        public int? min { get; set; }
        public int? max { get; set; }
    }
}
