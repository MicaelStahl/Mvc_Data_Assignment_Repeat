using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment_Repeat.Models
{
    public interface IPerson
    {
        // Create
        Person NewPerson(Person person);

        // Read All
        List<Person> AllPeople();

        // Read One
        Person FindPerson(int id);

        // Remove
        List<Person> RemovePerson(int id);

        // Update (Edit)
        Person EditPerson(int Id, Person person);

        // Update (sort)
        List<Person> SortList();

        // Update (Filter)
        List<Person> FilterList(string Filter);
    }
}
