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
        public IGadgetCommentsLikeDislikeRepository GadgetCommentsLikesDislikesRepository { get; }
        public IPurchaseRepository PurchaseRepository { get; }
        public IBannerRepository BannerRepository { get; }


        int Complete();
    }
}
