using SimpleCRUD.Models;
using SimpleCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCRUD.Controllers
{
    public class ElementController : Controller
    {
        private IElementRepository el = null;

        public ElementController()
        {
            //if the data hasn't been initialized yet, do so
            if (this.el == null)
            {
                Data.InitializeElements();
                this.el = new ElementRepository();
            }
            else
            {
                this.el = new ElementRepository();
            }
        }

        // 
        // Landing page
        //
        public ActionResult Index()
        {
            return View();
        }

        //
        // Show table view
        //
        public ActionResult ShowTable()
        {
            return View(el.SelectAll());
        }

        //
        // Show list view
        //
        public ActionResult ShowList()
        {
            return View(el.SelectAll());
        }

        //
        // Show detail view
        //
        public ActionResult ShowDetail(int atomicNumber)
        {
            return View(el.SelectByAtomicNumber(atomicNumber));
        }

        //
        // Show element to delete in detail view
        // 
        public ActionResult DeleteElement(int atomicNumber)
        {
            return View(el.SelectByAtomicNumber(atomicNumber));
        }

        //
        // Process request from delete element form
        //
        [HttpPost]
        public ActionResult DeleteElement(FormCollection form)
        {
            if (form["operation"] == "Delete")
            {
                try
                {
                    el.Delete(Convert.ToInt32(form["atomicNumber"]));
                }
                catch (ArgumentException)
                {
                    return Redirect("/Error/KnownError/delete");
                }
                catch(Exception)
                {
                    return Redirect("/Error/Index/");
                }
                
            }
            return Redirect("/Element/ShowTable");
        }

        //
        // Show new element form
        //
        public ActionResult CreateElement()
        {
            return View();
        }

        //
        // Process request from new element form
        //
        [HttpPost]
        public ActionResult CreateElement(FormCollection form)
        {
            if (form["operation"] == "Add")
            {
                Element e = new Element()
                {
                    name = form["name"], 
                    symbol = form["symbol"], 
                    atomicNumber = Convert.ToInt32(form["atomicNumber"]), 
                    atomicWeight = Convert.ToDouble(form["atomicWeight"]), 
                    isRadioactive = bool.Parse(form["isRadioactive"]), 
                    family = (AppEnum.Family)Enum.Parse(typeof(AppEnum.Family), form["family"]),
                    period = Convert.ToInt32(form["period"]),
                    atomicRadius = Convert.ToInt32(form["atomicRadius"])
                };
                try
                {
                    el.Insert(e);
                }
                catch (ArgumentException)
                {
                    return Redirect("/Error/KnownError/add");
                }
                catch (Exception)
                {
                    return Redirect("/Error/Index/");
                }

            }
            return Redirect("/Element/ShowTable");
        }

        //
        // Show element to update in edit view
        //
        public ActionResult UpdateElement(int atomicNumber)
        {
            return View(el.SelectByAtomicNumber(atomicNumber));
        }

        //
        // Process request from update element form
        //
        [HttpPost]
        public ActionResult UpdateElement(FormCollection form)
        {
            if (form["operation"] == "Update")
            {
                Element e = new Element()
                {
                    name = form["name"], 
                    symbol = form["symbol"], 
                    atomicWeight = Convert.ToDouble(form["atomicWeight"]), 
                    isRadioactive = bool.Parse(form["isRadioactive"]), 
                    family = (AppEnum.Family)Enum.Parse(typeof(AppEnum.Family), form["family"]),
                    period = Convert.ToInt32(form["period"]),
                    atomicRadius = Convert.ToInt32(form["atomicRadius"])
                };
                try
                {
                    el.Update(e);
                }
                catch (ArgumentException)
                {
                    return Redirect("/Error/KnownError/update");
                }
                catch (Exception)
                {
                    return Redirect("/Error/Index/");
                }

            }
            return Redirect("/Element/ShowTable");
        }

        //
        // Reload initial data set
        //
        public ActionResult ReloadData()
        {
            DAL.Data.InitializeElements();

            return Redirect("/Element/ShowTable");
        }
    }
}