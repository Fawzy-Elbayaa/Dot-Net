using MyShop.DataAcssess;
using MyShop.Entities;
using MyShop.Entities.Models;
using MyShop.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.Implementation
{
	public class ProductRepository : GenricRepository<Product>,IProductRepoSitory
	{
		private readonly ApplicationDbContext _context;
		public ProductRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(Product Product)
		{
			var ProductInDb = _context.Products.
				FirstOrDefault(x => x.Id == Product.Id);
			if (ProductInDb != null)
			{
				ProductInDb.Name = Product.Name;
				ProductInDb.Description = Product.Description;
				ProductInDb.Price = Product.Price;
				ProductInDb.Img = Product.Img;
				ProductInDb.CategoryId = Product.CategoryId;

			}
		}
	}
}
