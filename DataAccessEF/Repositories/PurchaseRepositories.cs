using DataAccessEF.Data;
using DataAccessEF.UnitOfWork;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace DataAccessEF.Repositories
{
    public class PurchaseRepositories : GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepositories(asp_tablesContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Purchase> GetAll()
        {
            foreach (var item in _dbContext.Purchases.ToList())
            {
                item.FkGadgets = _dbContext.Gadgets.Find(item.FkGadgetsId);
            }
            return _dbContext.Purchases.ToList();
        }
        public IEnumerable<Purchase> GetPurchaseByName(string nameID)
        {
            foreach (var item in _dbContext.Purchases.ToList())
            {
                item.FkGadgets = _dbContext.Gadgets.Find(item.FkGadgetsId);
            }
            return _dbContext.Purchases.AsEnumerable().Where(x => x.FkAspNetUsersId== nameID);
        }
        public IEnumerable<Purchase> GetPurchaseByBrandModel(string name)
        {
            foreach (var item in _dbContext.Purchases.ToList())
            {
                item.FkGadgets = _dbContext.Gadgets.Find(item.FkGadgetsId);
            }
            return _dbContext.Purchases.AsEnumerable().Where(x => x.FkGadgets.Name.ToLower().StartsWith(name) || x.FkGadgets.Model.ToLower().StartsWith(name));
        }
        public IEnumerable<Purchase> GetPurchaseFilter(string[]? nameModels, int? min, int? max) 
        {
            List<Purchase> purchase = new List<Purchase>();
            foreach (var item in _dbContext.Purchases.ToList())
            {
                item.FkGadgets = _dbContext.Gadgets.Find(item.FkGadgetsId);
            }
            foreach (var model in nameModels)
            {
                if (_dbContext.Gadgets.AsEnumerable().Any(x => x.Name == model) == true)
                {
                    purchase.AddRange(_dbContext.Purchases.AsEnumerable().Where(x => x.FkGadgets.Name == model));
                }
            }
            if (purchase.Count > 0)
            {
                return purchase.AsEnumerable().Where(x => x.TotalPrice >= min && x.TotalPrice <= max);
            }
            else
            {
                purchase.AddRange(_dbContext.Purchases);

                if (purchase.AsEnumerable().Where(x => x.TotalPrice >= min && x.TotalPrice <= max).Count() > 0)
                {
                    return purchase.AsEnumerable().Where(x => x.TotalPrice >= min && x.TotalPrice <= max);
                }
                else
                {
                    return purchase;
                }

            }
        }
        public Purchase GetId(int id)
        {
            return _dbContext.Purchases.Find(id);
        }
    }
}
