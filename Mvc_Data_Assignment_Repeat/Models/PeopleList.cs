using Mvc_Data_Assignment_Repeat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment_Repeat.Models
{
    public class PeopleList : IPerson
    {
        //public List<Person> personList = new List<Person>();
        PersonViewModel pvm = new PersonViewModel();

        private int idCount = 1;

        public PeopleList()
        {
            pvm.PersonList.Add(new Person() { Id = 0, Name = "Test Testsson", PhoneNumber = 123456789, City = "Viborg" });
        }

        public List<Person> AllPeople()
        {
            return pvm.PersonList;
        }

        public Person EditPerson(int Id, Person person)
        {
            foreach (Person item in pvm.PersonList)
            {
                if (item.Id == Id)
                {
                    item.Name = person.Name;
                    item.PhoneNumber = person.PhoneNumber;
                    item.City = person.City;
                    return item;
                }
            }
            return null;
        }

        public List<Person> FilterList(string filter)
        {
            var FilteredList = pvm.PersonList.Where(x => (x.Name + x.City).ToLower()
            .Contains(filter.ToLower())).ToList();

            return FilteredList;
        }

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

        public Person NewPerson(Person person)
        {
            Person newPerson = new Person() { Id = idCount, Name = person.Name, PhoneNumber = person.PhoneNumber, City = person.City, };
            idCount++;
            pvm.PersonList.Add(newPerson);
            return person;
        }

        public List<Person> RemovePerson(int id)
        {
            foreach (Person item in pvm.PersonList)
            {
                if (item.Id == id)
                {
                    pvm.PersonList.RemoveAt(id);
                    return pvm.PersonList;
                }
            }
            return null;
        }

        public List<Person> SortList()
        {
            pvm.PersonList.Sort();
            return pvm.PersonList;
        }
    }
}
