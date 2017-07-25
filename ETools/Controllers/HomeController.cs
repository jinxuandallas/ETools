﻿using System.Web.Mvc;
using ETools.Models;
using Ninject;

namespace ETools.Controllers {

    public class HomeController : Controller {
        private IValueCalculator calc;
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        /*
        public HomeController(IValueCalculator calcParam, IValueCalculator calc2) {
            calc = calcParam;
        }
        */

        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }
        public ActionResult Index() {
            /*
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
            */

            //LinqValueCalculator calc = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };

            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}
