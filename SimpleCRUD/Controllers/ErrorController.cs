using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCRUD.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            ViewBag.ErrorMessage = "Something went wrong, and we aren't sure what.";
            return View();
        }

        public ActionResult KnownError(string errorMessage)
        {
            switch (errorMessage)
            {
                case "delete":
                    errorMessage = "I can't seem to find the item you wanted to delete...";
                    break;
                case "add":
                    errorMessage = "That element number conflicts with an already existing one! Use the update feature if you want to change it.";
                    break;
                case "update":
                    errorMessage = "I can't seem to find the item you wanted to update...";
                    break;
                default:
                    errorMessage = "Something went wrong, and we aren't sure what.";
                    break;
            }
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }
    }
}