using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD.Models
{
    public class Element
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public int atomicNumber { get; set; }
        public double atomicWeight { get; set; }
        public bool isRadioactive { get; set; }
        public AppEnum.Family family { get; set; }
        public int period { get; set; }
        public int atomicRadius { get; set; }

        public Element()
        {

        }

        public Element(string _name, string _symbol, int _atomicNumber, double _atomicWeight, bool _isRadioactive, AppEnum.Family _family, int _period, int _atomicRadius)
        {
            name = _name;
            symbol = _symbol;
            atomicNumber = _atomicNumber;
            atomicWeight = _atomicWeight;
            isRadioactive = _isRadioactive;
            family = _family;
            period = _period;
            atomicRadius = atomicRadius;
        }
    }
}