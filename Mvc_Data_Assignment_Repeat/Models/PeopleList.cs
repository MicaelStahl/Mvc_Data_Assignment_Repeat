using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment_Repeat.Models
{
    public class PeopleList : IPerson
    {
        public List<Person> personList = new List<Person>();

        private int idCount = 1;

        public PeopleList()
        {
            personList.Add(new Person() { Id = 0, Name = "Test Testsson", PhoneNumber = 123456789, City = "Viborg" });
        }

        public List<Person> AllPeople()
        {
            return personList;
        }

        public Person EditPerson(int Id, Person person)
        {
            foreach (Person item in personList)
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
            List<Person> filteredList = personList.Where(x => x.Name.Contains(filter)).ToList();
            return filteredList;
        }

        public Person FindPerson(int id)
        {
            foreach (Person item in personList)
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
            personList.Add(newPerson);
            person.personList = personList;
            return person;
        }

        public List<Person> RemovePerson(int id)
        {
            foreach (Person item in personList)
            {
                if (item.Id == id)
                {
                    personList.RemoveAt(id);
                    return personList;
                }
            }
            return null;
        }

        public List<Person> SortList()
        {
            personList.Sort();
            return personList;
        }
    }
}
