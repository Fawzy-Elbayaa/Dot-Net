using MyShop.DataAcssess;
using MyShop.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.Implementation
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		public ICategoryRepoSitory Category { get; private set; }

		public IProductRepoSitory Product { get; private set; }

		public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
			Category = new CategoryRepository(context);
			Product = new ProductRepository(context);
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
