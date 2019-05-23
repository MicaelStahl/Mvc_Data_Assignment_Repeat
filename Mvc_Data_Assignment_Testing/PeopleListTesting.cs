using Mvc_Data_Assignment_Repeat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Mvc_Data_Assignment_Testing
{
    public class PeopleListTesting
    {
        [Fact]
        [Trait("Service", "AllPeople")]
        public void AllPeople_CallingAllPeople_Contains2People()
        {
            var peopleList = new PeopleList();

            var result = peopleList.AllPeople();

            Assert.Equal(2, result.Count());
        }


        [Fact]
        [Trait("Service", "Edit")]
        public void Edit_SendingEmptyName_WillReturnNull()
        {
            var peopleList = new PeopleList();
            var person = new Person() { Id = 1, City = "Viborg", PhoneNumber = 123123, Name = "" };

            var result = peopleList.EditPerson(person);

            Assert.Empty(result.Name);
        }
    }
}
