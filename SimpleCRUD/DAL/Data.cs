using SimpleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD.DAL
{
    public static class Data
    {
        public static void InitializeElements()
        {
            List<Element> elements = new List<Element>();

            elements.Add(new Element
            {
                name = "Hydrogen",
                symbol = "H",
                atomicNumber = 1,
                atomicWeight = 1.008,
                isRadioactive = false,
                family = AppEnum.Family.Lithium,
                period = 1,
                atomicRadius = 110
            });

            elements.Add(new Element
            {
                name = "Helium",
                symbol = "He",
                atomicNumber = 2,
                atomicWeight = 4.003,
                isRadioactive = false,
                family = AppEnum.Family.Helium,
                period = 1,
                atomicRadius = 140
            });

            elements.Add(new Element
            {
                name = "Lithium",
                symbol = "Li",
                atomicNumber = 3,
                atomicWeight = 6.94,
                isRadioactive = false,
                family = AppEnum.Family.Lithium,
                period = 2,
                atomicRadius = 181
            });

            HttpContext.Current.Session["Elements"] = elements;
        }
    }
}