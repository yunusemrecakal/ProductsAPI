using Microsoft.AspNetCore.Mvc;
using ProductsMVC.Models;

namespace ProductsMVC.Controllers
{
    public class ProductsInBasketController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<MVCProductInBasket> products;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ProductsInBasket").Result;
            products = response.Content.ReadAsAsync<IEnumerable<MVCProductInBasket>>().Result;
            return View(products);
        }
    }
}
