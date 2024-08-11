using MyShoppy.DataAccess.Data;
using MyShoppy.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppy.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public ICategoryRepo Category { get; private set; }


        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Category = new CategoryRepo(context);
        }



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
