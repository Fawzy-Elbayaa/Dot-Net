using Microsoft.EntityFrameworkCore;
using MyShop.DataAcssess;
using MyShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.Implementation
{
	public class GenricRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		private DbSet<T> _dbSet;
        public GenricRepository(ApplicationDbContext context)
        {
			_context = context;
			_dbSet = _context.Set<T>();

		}
        public void Add(T entity)
		{
			//_context.Categories.Add(entitity);
			_dbSet.Add(entity);
		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? Predicate = null, string? IncludeWord = null)
		{
			IQueryable<T> query = _dbSet;
			if(Predicate != null)
			{
				query = query.Where(Predicate);
			}
			if(IncludeWord != null)
			{
				//_context_Categories.Include(Category , users , product)
				foreach(var item in IncludeWord.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(item);
				}
			}
			return query.ToList();
		}

		public T GetFirstOrDefault(Expression<Func<T, bool>>? Predicate = null, string? IncludeWord = null)
		{
			IQueryable<T> query = _dbSet;
			if (Predicate != null)
			{
				query = query.Where(Predicate);
			}
			if (IncludeWord != null)
			{
				//_context_Categories.Include(Category , users , product)
				foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(item);
				}
			}
			return query.SingleOrDefault();
		}

		public void Remove(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_dbSet.RemoveRange(entities);
		}
	}
}
