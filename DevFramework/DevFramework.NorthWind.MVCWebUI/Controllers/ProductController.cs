﻿using DevFramework.NorthWind.Business.Abstract;
using DevFramework.NorthWind.Entities.Concrete;
using DevFramework.NorthWind.MVCWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DevFramework.NorthWind.MVCWebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product { CategoryId = 1, ProductName = "GSM", QuantityPerUnit = "1", UnitPrice = 21 });
            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "Computer",
                QuantityPerUnit = "1",
                UnitPrice = 2
            },
            new Product
            {
                CategoryId = 1,
                ProductName = "Computer2",
                QuantityPerUnit = "1",
                UnitPrice = 22,
                ProductId = 2
            });
            return "Done";
        }
    }
}