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
    public class UserRepositories : GenericRepository<User>, IUserRepository
    {
        public UserRepositories(asp_tablesContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<User> GetAll() => _dbContext.Users.ToList();

        public User GetId(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Buy(int id, object find)
        {
            var user = _dbContext.Users.Find(find);
            user.IdGadget = id;
            _dbContext.SaveChanges();
        }
    }
}
