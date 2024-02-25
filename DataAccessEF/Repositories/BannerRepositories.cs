using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Repositories
{
    public class BannerRepositories : GenericRepository<Banner>, IBannerRepository
    {
        public BannerRepositories(asp_tablesContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Banner> GetAll()
        {
            foreach (var item in _dbContext.Banner.ToList())
            {
                item.FkGadgets = _dbContext.Gadgets.Find(item.FkGadgetsId);
            }
            return _dbContext.Banner.ToList();
        }
    }
}
