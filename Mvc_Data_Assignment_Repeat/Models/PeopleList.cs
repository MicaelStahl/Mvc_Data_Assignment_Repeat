using Mvc_Data_Assignment_Repeat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment_Repeat.Models
{
    public class PeopleList : IPerson
    {
        PersonViewModel pvm = new PersonViewModel();

        private int idCount = 2;

        /// <summary>
        /// Creates a static member in the list that always shows up when the website opens anew.
        /// </summary>
        public PeopleList()
        {
            pvm.PersonList.Add(new Person()
            {
                Id = 1,
                Name = "Test Testsson",
                PhoneNumber = 123456789,
                City = "Viborg"
            });
            pvm.PersonList.Add(new Person()
            {
                Id = 1000,
                Name = "Testing Testare",
                PhoneNumber = 123456789,
                City = "Vetlanda"
            });
        }

        /// <summary>
        /// Returns all members in the list.
        /// </summary>
        public List<Person> AllPeople()
        {
            return pvm.PersonList;
        }

        /// <summary>
        /// This method requests a person and edits it after the requested input from the user.
        /// </summary>
        public Person EditPerson(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.Name) || string.IsNullOrWhiteSpace(person.City) || person.PhoneNumber == 0 || person.PhoneNumber == null)
            {
                return null;
            }

            var original = pvm.PersonList.SingleOrDefault(x => x.Id == person.Id);

            if (original != null)
            {
                original.Name = person.Name;
                original.City = person.City;
                original.PhoneNumber = person.PhoneNumber;

                return original;
            }
            return null;
        }

        /// <summary>
        /// This method filters the list by using a "simple" lambda expression
        /// </summary>
        public List<Person> FilterList(string Filter)
        {
            var FilteredList = pvm.PersonList.Where(x => (x.Name + x.City).ToLower()
            .Contains(Filter.ToLower())).ToList();

            return FilteredList;
        }

        /// <summary>
        /// Searches for a specific person in the list by using Id.
        /// </summary>
        public Person FindPerson(int id)
        {
            foreach (Person item in pvm.PersonList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// This creates a new person with the requested Name, PhoneNumber and City by the user.
        /// </summary>
        public Person NewPerson(Person person)
        {
            Person newPerson = new Person() { Id = idCount, Name = person.Name, PhoneNumber = person.PhoneNumber, City = person.City, };
            idCount++;
            pvm.PersonList.Add(newPerson);
            return newPerson;
        }

        /// <summary>
        /// This method looks through the list of users and removes the user that has the wanted Id.
        /// </summary>
        public bool RemovePerson(int id)
        {
            var person = pvm.PersonList.SingleOrDefault(x => x.Id == id);

            if (person != null)
            {
                pvm.PersonList.Remove(person);

                return true;
            }

            return false;
        }
    }
}
