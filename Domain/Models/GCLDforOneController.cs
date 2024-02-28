using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class GCLDforOneController
    {
        public GCLDforOneController() { }
        public GCLDforOneController(int _Id) {
            this.Id = _Id;
        }
        public int Id { get; set; }
        
    }
}
