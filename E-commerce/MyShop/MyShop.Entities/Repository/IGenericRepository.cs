using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Entities
{
	public interface IGenericRepository<T> where T : class
	{
		//_context.Categories.Incluse(Product).ToList();
		//_context.Categories.Where(x=> x.Id==id).ToList();
		IEnumerable<T> GetAll(Expression<Func<T, bool>>? Predicate = null, string? IncludeWord = null);

		//_context.Categories.Incluse(Product).SingleOrDefault();
		//_context.Categories.Where(x=> x.Id==id).SingleOrDefault();
		T GetFirstOrDefault(Expression<Func<T, bool>>? Predicate = null, string? IncludeWord = null);

		//_context.Categories.Add();
		void Add(T entity);
		//_context.Categories.Remove();
		void Remove(T entity);

		void RemoveRange(IEnumerable<T> entities);



	}
}
