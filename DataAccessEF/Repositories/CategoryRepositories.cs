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
    public class CategoryRepositories : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepositories(asp_tablesContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Category> GetAll() => _dbContext.Categories.ToList();

        public Category GetId(int? id)
        {
            return _dbContext.Categories.Find(id);
        }
    }
}
