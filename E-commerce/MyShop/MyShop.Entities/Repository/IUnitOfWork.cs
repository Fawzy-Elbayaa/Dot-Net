using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Entities.Repository
{
	public interface IUnitOfWork: IDisposable
	{
		ICategoryRepoSitory Category {  get; }
		IProductRepoSitory Product { get; }

		int Complete();
	}
}
