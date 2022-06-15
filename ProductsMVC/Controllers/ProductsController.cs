using Microsoft.AspNetCore.Mvc;
using ProductsMVC.Models;

namespace ProductsMVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<MVCProduct> products;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            products = response.Content.ReadAsAsync<IEnumerable<MVCProduct>>().Result;
            return View(products);
        }
    }
}
