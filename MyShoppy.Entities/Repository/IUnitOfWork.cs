using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppy.Entities.Repository
{
    // Used to Save on DB
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepo Category { get; }

        int Complete();
    }
}
