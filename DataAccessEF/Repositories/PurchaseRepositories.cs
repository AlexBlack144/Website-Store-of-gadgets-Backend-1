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
    public class PurchaseRepositories : GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepositories(asp_tablesContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Purchase> GetAll() => _dbContext.Purchases.ToList();
        public IEnumerable<Purchase> GetPurchaseByName(string nameID)
        {
            return _dbContext.Purchases.AsEnumerable().Where(x => x.FkAspNetUsersId== nameID);
        }

        public Purchase GetId(int id)
        {
            return _dbContext.Purchases.Find(id);
        }
    }
}
