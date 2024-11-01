﻿using MyShop.DataAcssess;
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
	public class CategoryRepository : GenricRepository<Category>,ICategoryRepoSitory
	{
		private readonly ApplicationDbContext _context;
		public CategoryRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(Category category)
		{
			var CategoryInDb = _context.Categories.
				FirstOrDefault(x => x.Id == category.Id);
			if (CategoryInDb != null)
			{
				CategoryInDb.Name = category.Name;
				CategoryInDb.Description = category.Description;
				CategoryInDb.CreatedTime = DateTime.Now;
			}
		}
	}
}
