using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_Data_Assignment_Repeat.Models;
using Mvc_Data_Assignment_Repeat.ViewModels;

namespace Mvc_Data_Assignment_Repeat.Controllers
{
    public class HomeController : Controller
    {

        private const string SessionKeyFiltered = "_Filtered";

        IPerson _person;

        public HomeController(IPerson person)
        {
            _person = person;
        }

        public IActionResult Index(PersonViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                pvm.Filter = HttpContext.Session.GetString("_Filtered");

                if (pvm.Filter != null)
                {
                    HttpContext.Session.Remove("_Filtered");
                    pvm.PersonList = _person.FilterList(pvm.Filter);
                }
                else
                {
                    pvm.PersonList = _person.AllPeople();
                }
                return View(pvm);
            }
            return View();
        }

        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                if (person.Name == null || person.PhoneNumber == null || person.City == null)
                {
                    return NotFound();
                }
                _person.NewPerson(person);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Person", person);
        }
        [HttpGet]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                var item = _person.FindPerson(person.Id);

                if (item == null)
                {
                    return View();
                }
                return PartialView("_Edit", item);
            }
            return PartialView("_Person", person);
        }

        // For whenever I see this, use PARTIALVIEWS for AJAX. that's how it'll be fluid.

        [HttpPost, ActionName("Edit")]
        public IActionResult EditComplete(Person person)
        {
            if (ModelState.IsValid)
            {
                var item = _person.EditPerson(person);

                return RedirectToAction(nameof(Index));
                //return PartialView("_Person", item);
            }
            return PartialView("_Person", person);
        }

        public IActionResult Delete(Person person)
        {
            if (ModelState.IsValid)
            {
                _person.RemovePerson(person.Id);

                return View();
            }
            return PartialView("_Person", person);
        }

        public IActionResult Filter(PersonViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                if (pvm.Filter != null)
                {
                    HttpContext.Session.SetString("_Filtered", pvm.Filter);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pvm);
        }
    }
}