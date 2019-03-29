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
        PersonViewModel pvm = new PersonViewModel();


        IPerson _person;

        public HomeController(IPerson person)
        {
            _person = person;
        }
        /// <summary>
        /// The Index. This 
        /// </summary>
        public IActionResult Index()
        {
            pvm.PersonList = _person.AllPeople();

            return View(pvm);
        }

        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(person.Name)
                    || person.PhoneNumber > int.MaxValue || person.PhoneNumber < int.MinValue
                    || string.IsNullOrWhiteSpace(person.City))
                {
                    return NotFound();
                }
                var item = _person.NewPerson(person);
                return PartialView("_Person", item);
            }
            return Content("");
        }

        public IActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                _person.RemovePerson((int)Id);
                return View();
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id != null)
            {

                var item = _person.FindPerson((int)Id);

                if (item == null)
                {
                    return View();
                }
                return PartialView("_Edit", item);
            }
            return View();
        }

    [HttpPost]
    public IActionResult Edit(Person person)
    {
        if (ModelState.IsValid)
        {
            var item = _person.EditPerson(person);

            return PartialView("_Person", item);
        }
            return Content("");
    }

    public IActionResult Filter(PersonViewModel pvm)
    {
        if (ModelState.IsValid)
        {
            if (!string.IsNullOrWhiteSpace(pvm.Filter))
            {
                pvm.PersonList = _person.FilterList(pvm.Filter);

                return PartialView("_List", pvm);
            }
            pvm.PersonList = _person.AllPeople();
        }
        return PartialView("_List", pvm);
    }
}
}