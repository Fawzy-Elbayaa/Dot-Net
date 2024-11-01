using Microsoft.AspNetCore.Mvc;
using MyShop.DataAccess.Implementation;
using MyShop.Entities.Repository;
using MyShop.Entities.ViewModels;

namespace MyShop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var products = _unitOfWork.Product.GetAll();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            ShoppingCart obj = new ShoppingCart()
            {
                Product = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == id, IncludeWord: "category"),
                Count = 1
            };
          
            return View(obj);
        }
    }
}
