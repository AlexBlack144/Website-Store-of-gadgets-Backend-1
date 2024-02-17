using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Repositories
{
    public class GadgetCommentsLikeDislikeRepositories : GenericRepository<GadgetCommentsLikeDislike>, IGadgetCommentsLikeDislikeRepository
    {
        public GadgetCommentsLikeDislikeRepositories(asp_tablesContext dbContext) : base(dbContext)
        { 
        }
        public IEnumerable<GadgetCommentsLikeDislike> GetAll() => _dbContext.GadgetCommentsLikeDisliks.ToList();
        public GadgetCommentsLikeDislike GetId(int id)
        {
            return _dbContext.GadgetCommentsLikeDisliks.Find(id);
        }
        public IEnumerable<GadgetCommentsLikeDislike> GetbyIdGadget(int id)
        {
            return _dbContext.GadgetCommentsLikeDisliks.AsEnumerable().Where(x => x.FkGadgetsId == id);
        }
        public IEnumerable<GadgetCommentsLikeDislike> GetbyIdUser(string id)
        {
            return _dbContext.GadgetCommentsLikeDisliks.AsEnumerable().Where(x => x.FkAspNetUsersId == id);
        }
    }
}
