using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get; }
        public IGadgetRepository GadgetRepository { get; }
        public IUserRepository UserRepository { get; }
        public IPurchaseRepository PurchaseRepository { get; }

        int Complete();
    }
}
