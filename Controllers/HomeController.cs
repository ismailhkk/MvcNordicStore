using Microsoft.AspNetCore.Mvc;
using MvcNordicStore.Models;
using System.Diagnostics;

namespace MvcNordicStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var product = new List<Product>();

            using StreamReader reader = new StreamReader("AppData/index.txt");
            var productData = reader.ReadToEnd();
            var productLines = productData.Split('\n');
            foreach (var line in productLines)
            {
                var productParts = line.Split('|');
                product.Add(
                    new Product()
                    {
                        Name = productParts[0],
                        Price = int.Parse(productParts[1]),
                        Currency = productParts[2],
                        Img = productParts[3]
                    }
                );
            }
            ViewBag.Products = product;

            return View();
        }

    }
}
