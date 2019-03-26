using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment_Repeat.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PhoneNumber { get; set; }
        public string City { get; set; }
        public List<Person> personList { get; set; }
    }
}
