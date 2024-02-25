using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {
        IEnumerable<Purchase> GetPurchaseByName(string name);
        IEnumerable<Purchase> GetPurchaseByBrandModel(string name);
        IEnumerable<Purchase> GetPurchaseFilter(string[]? nameModels, int? min, int? max);
        
    }
}
