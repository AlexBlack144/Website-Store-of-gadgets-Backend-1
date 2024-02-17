using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGadgetCommentsLikeDislikeRepository : IGenericRepository<GadgetCommentsLikeDislike>
    {
        IEnumerable<GadgetCommentsLikeDislike> GetbyIdGadget(int id);
        IEnumerable<GadgetCommentsLikeDislike> GetbyIdUser(string id);
    }
}
