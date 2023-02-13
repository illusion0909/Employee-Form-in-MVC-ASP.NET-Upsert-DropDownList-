using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNet_Project8.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DemoFirst()
        {
            ViewData["vdata"] = "My View Data";///1-----//2
            //return View();//1
            
            TempData["tdata"] = "My Temp Data";
            TempData.Keep();
            // return RedirectToAction("DemoSecond");//----2
            // return RedirectToAction("Index", "Employee");//3

            
            return View();
        }
        public ActionResult DemoSecond()
        {
            //ViewData["vdata"] = "My View Data";---1
            //return View();  //first time check action to view scope in ViewData which send request action to view--1
            var vdata = ViewData["vdata"];//scope of viewdata Action to View .....
            var tdata = TempData["tdata"];//scope of temp datata is action to action or controller to controller also !!
            return View();
        }
    }
}