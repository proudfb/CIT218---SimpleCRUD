using SimpleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//much of this back-end code was lifted from https://github.com/NMC-CIT218/Demo_NMM.Basic
namespace SimpleCRUD.DAL
{
    public class ElementRepository : IElementRepository
    {
        private List<Element> elements = null;

        public ElementRepository()
        {
            this.elements = (List<Element>)HttpContext.Current.Session["Elements"];
        }

        public ElementRepository(List<Element> elements)
        {
            this.elements = elements;
        }

        public IEnumerable<Element> SelectAll()
        {
            return this.elements;
        }

        /// <summary>
        /// Select a group of elements based on their periodic family
        /// </summary>
        /// <param name="family">The family to search for, from the AppEnum.Family enumerable</param>
        /// <returns>List of Element</returns>
        public IEnumerable<Element> SelectEachMember(AppEnum.Family family)
        {
            List<Element> searchResults = new List<Element>();
            //if there are no elements in the list
            if (!this.elements.Any())
            {
                //throw an exception
                throw new ArgumentException("EmptyList");
            }

            //otherwise, look through all the existing elements for any matches
            foreach (Element element in this.elements)
            {
                if (element.family == family)
                {
                    searchResults.Add(element);
                }
            }

            //if no matches were found, throw an exception
            if (!searchResults.Any())
            {
                throw new ArgumentException("FamilyMembersNotFound");
            }

            //otherwise, return the list of results
            return searchResults;
        }

        public Element SelectByAtomicNumber(int atomicNumber)
        {
            var index = elements.FindIndex(a => a.atomicNumber == atomicNumber);
            if (index != -1) return this.elements[index];
            else throw new ArgumentException("ElementNotFound");
        }

        public void Insert(Element element)
        {
            //if the element already exists
            if (this.elements.Exists(a => a.atomicNumber == element.atomicNumber))
            {
                //cancel the addition and inform the user
                throw new ArgumentException("ElementAlreadyExists");
            }
            //otherwise, add it
            else this.elements.Add(element);
        }

        public void Update(Element element)
        {
            var index = this.elements.FindIndex(a => a.atomicNumber == element.atomicNumber);

            if (index != -1) this.elements[index] = element;
            else throw new ArgumentException("ElementNotFound");
        }

        public void Delete(int atomicNumber)
        {
            var index = this.elements.FindIndex(a => a.atomicNumber == atomicNumber);

            if (index != -1) this.elements.RemoveAt(index);
            else throw new ArgumentException("ElementNotFound");
        }

        public void Dispose()
        {
            //let garbage collector handle disposal
        }
    }
}