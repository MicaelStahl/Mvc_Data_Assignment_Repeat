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

        /// <summary>
        /// D.I
        /// </summary>
        public HomeController(IPerson person)
        {
            _person = person;
        }

        /// <summary>
        /// The Index. Always sends out the list to the website.
        /// </summary>
        public IActionResult Index()
        {
            pvm.PersonList = _person.AllPeople();

            return View(pvm);
        }

        /// <summary>
        /// This action verifies the values aren't null nor exceeding the possible int values.
        /// if one or several values are, then nothing will return.
        /// </summary>
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                var item = _person.CreatePerson(person);

                if (item != null)
                {
                    return PartialView("_Person", item);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// This action gets a specific user by Id and then deletes it.
        /// </summary>
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return BadRequest();
            }

            var boolean = _person.RemovePerson((int)Id);

            if (boolean)
            {
                return View(boolean);
            }
            return NotFound();
        }

        /// <summary>
        /// This action gets a specific user by Id and then sends it out to the website.
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return BadRequest();
            }

            var item = _person.FindPerson((int)Id);

            if (item != null)
            {
                return PartialView("_Edit", item);
            }
            return NotFound();
        }

        /// <summary>
        /// This action edits the values of a person after the request of the user.
        /// </summary>
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                var item = _person.EditPerson(person);

                if (item != null)
                {
                    return PartialView("_Person", item);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// This action filters the list after the request of the user.
        /// </summary>
        public IActionResult Filter(PersonViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrWhiteSpace(pvm.Filter))
                {
                    pvm.PersonList = _person.FilterList(pvm.Filter);

                    return PartialView("_List", pvm);
                }
                return RedirectToAction(nameof(Index));
            }
            return BadRequest(ModelState);
        }
    }
}