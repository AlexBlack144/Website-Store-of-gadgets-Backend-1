using DataAccessEF.Data;
using DataAccessEF.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }

        public IGadgetRepository GadgetRepository { get; }

        public IUserRepository UserRepository { get; }

        public IPurchaseRepository PurchaseRepository { get; }

        private readonly asp_tablesContext _dbContect;

        public UnitOfWork(asp_tablesContext dbContect)
        {
            this._dbContect = dbContect;
            CategoryRepository = new CategoryRepositories(dbContect);
            GadgetRepository = new GadgetRepositories(dbContect);
            UserRepository = new UserRepositories(dbContect);
            PurchaseRepository = new PurchaseRepositories(dbContect);
        }

        public int Complete() => _dbContect.SaveChanges();
      
    

        public void Dispose() => _dbContect.Dispose();
      
    }
}
