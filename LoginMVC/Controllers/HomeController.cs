﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
  
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "HEALTHY AND ORGANIC PRODUCTS";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "POINT OF CONTACT";

            return View();
        }
    }
}