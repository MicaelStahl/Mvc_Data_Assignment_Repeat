using Mvc_Data_Assignment_Repeat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment_Repeat.ViewModels
{
    public class PersonViewModel
    {
        /// <summary>
        /// This is the View Model that holds the List of all the people
        /// and a string that contains a filter.
        /// </summary>

        public List<Person> PersonList = new List<Person>();

        public string Filter { get; set; }
    }
}
