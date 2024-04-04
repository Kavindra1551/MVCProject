using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        UserdataEntities db = new UserdataEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderViews()
        {
            return View(db.Orders.ToList());
        }
    }
}