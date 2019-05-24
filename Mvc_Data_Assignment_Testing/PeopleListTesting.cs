using Mvc_Data_Assignment_Repeat.Models;
using Mvc_Data_Assignment_Repeat.ViewModels;
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
            var person = new Person() { Id = 1, City = "Viborg", PhoneNumber = "123123", Name = "" };

            var result = peopleList.EditPerson(person);

            Assert.Null(result);
        }

        [Fact]
        [Trait("Service", "Edit")]
        public void Edit_SendingNoName_WillReturnNull()
        {
            var peopleList = new PeopleList();
            var person = new Person() { Id = 1, Name = null, City = "Viborg", PhoneNumber = "123123" };

            var result = peopleList.EditPerson(person);

            Assert.Null(result);
        }

        [Fact]
        [Trait("Service", "Edit")]
        public void Edit_SendingInvalidId_WillReturnNull()
        {
            var peopleList = new PeopleList();
            var person = new Person() { Id = 2, Name = "test testsson", City = "TestCity", PhoneNumber = "123123" };
        }

        [Fact]
        [Trait("Service", "Edit")]
        public void Edit_SendingCorrectValues_WillReturnUpdatedPerson()
        {
            var peopleList = new PeopleList();
            var person = new Person() { Id = 1, Name = "test testing", City = "Stockholm", PhoneNumber = "123123123" };

            var result = peopleList.EditPerson(person);

            Assert.Equal(person.Id, result.Id);
            Assert.Equal(person.Name, result.Name);
            Assert.Equal(person.City, result.City);
            Assert.Equal(person.PhoneNumber, result.PhoneNumber);
        }


        [Fact]
        [Trait("Service", "Filter")]
        public void Filter_SubmittingValidFilter_ReturnsFilteredList()
        {
            var peopleList = new PeopleList();
            var pvm = new PersonViewModel
            {
                Filter = "Testsson",
            };

            var result = peopleList.FilterList(pvm.Filter);

            Assert.Single(result);
        }

        [Fact]
        [Trait("Service", "Filter")]
        public void Filter_SubmittingInvalidFilter_ReturnsNullValue()
        {
            var peopleList = new PeopleList();
            var pvm = new PersonViewModel
            {
                Filter = null,
            };

            var result = peopleList.FilterList(pvm.Filter);

            Assert.Null(result);
        }


        [Fact]
        [Trait("Service", "FindPerson")]
        public void FindPerson_SubmitNullId_ReturnsNullValue()
        {
            var peopleList = new PeopleList();

            var result = peopleList.FindPerson(null);

            Assert.Null(result);
        }

        [Fact]
        [Trait("Service", "FindPerson")]
        public void FindPerson_SubmitInvalidId_ReturnsNullValue()
        {
            var peopleList = new PeopleList();

            var result = peopleList.FindPerson(0);

            Assert.Null(result);
        }

        [Fact]
        [Trait("Service", "FindPerson")]
        public void FindPerson_SubmitNonExistingId_ReturnsNullValue()
        {
            var peopleList = new PeopleList();

            var result = peopleList.FindPerson(3);

            Assert.Null(result);
        }

        [Fact]
        [Trait("Service", "FindPerson")]
        public void FindPerson_SubmitValidId_ReturnsCorrectPerson()
        {
            var peopleList = new PeopleList();

            var result = peopleList.FindPerson(1);

            Assert.Equal("Test Testsson", result.Name);
        }

        [Fact]
        [Trait("Service", "CreatePerson")]
        public void CreatePerson_SubmitValidPerson_Returns3PeopleInList()
        {
            var peopleList = new PeopleList();
            var person = new Person() { Name = "Micael Ståhl", City = "Vetlanda", PhoneNumber = "0725539574" };
            var pvm = new PersonViewModel();

            var result = peopleList.CreatePerson(person);
            pvm.PersonList = peopleList.AllPeople();

            Assert.Equal(3, pvm.PersonList.Count);
        }


        [Fact]
        [Trait("Service", "CreatePerson")]
        public void CreatePerson_SubmitValidPerson_ReturnsCreatedPerson()
        {
            var peopleList = new PeopleList();
            var person = new Person() { Name = "Micael Ståhl", City = "Vetlanda", PhoneNumber = "0725539574" };

            var result = peopleList.CreatePerson(person);

            Assert.Equal(2, result.Id);
            Assert.Equal(person.Name, result.Name);
            Assert.Equal(person.City, result.City);
            Assert.Equal(person.PhoneNumber, result.PhoneNumber);
        }

        [Fact]
        [Trait("Service", "CreatePerson")]
        public void CreatePerson_SubmitInvalidPerson_ReturnsNullValue()
        {
            var peopleList = new PeopleList();
            var person = new Person() { Name = "", City = "Vetlanda", PhoneNumber = "0725539574" };

            var result = peopleList.CreatePerson(person);

            Assert.Null(result);
        }

        [Fact]
        [Trait("Service", "CreatePerson")]
        public void CreatePerson_SubmitId_ReturnsNullValue()
        {
            var peopleList = new PeopleList();
            var person = new Person() { Id = 2, Name = "Micael Ståhl", City = "Vetlanda", PhoneNumber = "0725539574" };

            var result = peopleList.CreatePerson(person);

            Assert.Null(result);
        }


        [Fact]
        [Trait("Service", "DeletePerson")]
        public void DeletePerson_SubmitInvalidId_ReturnsFalseValue()
        {
            var peopleList = new PeopleList();

            var result = peopleList.RemovePerson(3);

            Assert.False(result);
        }

        [Fact]
        [Trait("Service", "DeletePerson")]
        public void DeletePerson_SubmitValidId_ReturnsTrueValue()
        {
            var peopleList = new PeopleList();

            var result = peopleList.RemovePerson(1);

            Assert.True(result);
        }

        [Fact]
        [Trait("Service", "DeletePerson")]
        public void DeletePerson_SubmitNullId_ReturnsFalseValue()
        {
            var peopleList = new PeopleList();

            var result = peopleList.RemovePerson(null);

            Assert.False(result);
        }

        [Fact]
        [Trait("Service", "DeletePerson")]
        public void DeletePerson_SubmitValidId_Return1ValueInList()
        {
            var peopleList = new PeopleList();
            var pvm = new PersonViewModel();

            var result = peopleList.RemovePerson(1);
            pvm.PersonList = peopleList.AllPeople();

            Assert.Single(pvm.PersonList);
        }
    }
}
