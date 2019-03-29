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

        private int idCount = 1;

        /// <summary>
        /// Creates a static member in the list that always shows up when the website opens anew.
        /// </summary>
        public PeopleList()
        {
            pvm.PersonList.Add(new Person() { Id = 0, Name = "Test Testsson", PhoneNumber = 123456789, City = "Viborg" });
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
            foreach (Person item in pvm.PersonList)
            {
                if (item.Id == person.Id)
                {
                    item.Name = person.Name;
                    item.PhoneNumber = person.PhoneNumber;
                    item.City = person.City;
                    return item;
                }
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
        public List<Person> RemovePerson(int id)
        {
            foreach (Person item in pvm.PersonList)
            {
                if (item.Id == id)
                {
                    pvm.PersonList.Remove(item);
                    return pvm.PersonList;
                }
            }
            return null;
        }
    }
}
