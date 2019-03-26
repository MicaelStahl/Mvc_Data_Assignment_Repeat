﻿using System;
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

        public IActionResult Index()
        {
            PersonViewModel pvm = new PersonViewModel();
            
            string filter = HttpContext.Session.GetString("_Filtered");

            if (filter != null)
            {
                HttpContext.Session.Remove("_Filtered");
                pvm.PersonList = _person.FilterList(filter);
            }
            else
            {
                pvm.PersonList = _person.AllPeople();
            }
            return View(pvm);
        }

        public IActionResult Create(int Id, Person person)
        {
            if (ModelState.IsValid)
            {
                if (person.Name == null || person.PhoneNumber == null || person.City == null)
                {
                    return RedirectToAction(nameof(Index));

                }
                _person.NewPerson(person);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            _person.RemovePerson(Id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Filter(string filter)
        {
            if (filter != null)
            {
                HttpContext.Session.SetString("_Filtered", filter);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}