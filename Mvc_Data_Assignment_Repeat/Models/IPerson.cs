using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment_Repeat.Models
{
    public interface IPerson
    {
        /// <summary>
        /// This interface contains all the methods and fields used in the 
        /// Mock-Class, which in this case is the "PeopleList-class"
        /// </summary>

        // Create
        Person NewPerson(Person person);

        // Read All
        List<Person> AllPeople();

        // Read One
        Person FindPerson(int id);

        // Remove
        bool RemovePerson(int id);

        // Update (Edit)
        Person EditPerson(Person person);

        // Update (Filter)
        List<Person> FilterList(string Filter);
    }
}
