using Microsoft.AspNetCore.Mvc;
using Mvc_Data_Assignment_Repeat.Controllers;
using Mvc_Data_Assignment_Repeat.Models;
using Mvc_Data_Assignment_Repeat.ViewModels;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Mvc_Data_Assignment_Testing
{
    public class HomeControllerTesting
    {
        [Fact]
        [Trait("Category", "Index")]
        public void Index_RequestListOfPeople_ReturnsListsOfPeople()
        {
            var homeController = new HomeController(new PeopleList());

            var result = homeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PersonViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, model.PersonList.Count());
        }


        [Fact]
        [Trait("Category", "Create")]
        public void Create_CreateNewPerson_ReturnsNewlyCreatedPerson()
        {
            var homeController = new HomeController(new PeopleList());
            var person = new Person() { Id = 1, Name = "Micael Ståhl", PhoneNumber = 0725539574, City = "Vetlanda" };

            var result = homeController.Create(person);

            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<Person>(viewResult.ViewData.Model);
            Assert.Equal(person.Id, model.Id);
        }

        [Fact]
        [Trait("Category", "Create")]
        public void Create_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            var homeController = new HomeController(new PeopleList());
            homeController.ModelState.AddModelError("SessionName", "Required");
            var person = new Person() { City = "Vetlanda", PhoneNumber = 1235412, Id = 1 };

            var result = homeController.Create(person);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        [Trait("Category", "Create")]
        public void Create_ReturnsPartialViewResult_WhenModelStateIsValid()
        {
            var homeController = new HomeController(new PeopleList());

            var person = new Person() { Name = "Micael Ståhl", Id = 1, PhoneNumber = 1234567, City = "Viborg" };

            var result = homeController.Create(person);

            Assert.IsType<PartialViewResult>(result);

        }


        [Fact]
        [Trait("Category", "Delete")]
        public void Delete_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            var homeController = new HomeController(new PeopleList());

            var result = homeController.Delete(2) as NotFoundResult;

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        [Trait("Category", "Delete")]
        public void Delete_NoIdPassed_ReturnsBadRequestResponse()
        {
            var homeController = new HomeController(new PeopleList());

            var result = homeController.Delete(null) as BadRequestResult;

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        [Trait("Category", "Delete")]
        public void Delete_ExistingIdPassed_ReturnsViewResult()
        {
            var actualId = 1;
            var homeController = new HomeController(new PeopleList());

            var result = homeController.Delete(actualId);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        [Trait("Category", "Delete")]
        public void Delete_ExistingIdPassed_Removes1FromList()
        {
            var actualId = 1;
            var homeController = new HomeController(new PeopleList());

            var result = homeController.Delete(actualId);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<bool>(viewResult.Model);
            Assert.True(model);
        }


        [Fact]
        [Trait("Category", "Edit")]
        public void EditGet_ExistingIdPassed_ReturnsCorrectPerson()
        {
            var homeController = new HomeController(new PeopleList());
            var person = new Person() { Id = 1, Name = "Test Testsson", PhoneNumber = 123456789, City = "Viborg" };

            var result = homeController.Edit(1);

            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<Person>(viewResult.ViewData.Model);
            Assert.Equal(person.Id, model.Id);
            Assert.Equal(person.Name, model.Name);
            Assert.Equal(person.PhoneNumber, model.PhoneNumber);
            Assert.Equal(person.City, model.City);
        }

        [Fact]
        [Trait("Category", "Edit")]
        public void EditGet_NonExistingIdPassed_ReturnsNotFoundResponse()
        {
            var homeController = new HomeController(new PeopleList());

            var result = homeController.Edit(2) as NotFoundResult;

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        [Trait("Category", "Edit")]
        public void EditGet_NoIdPassed_ReturnsBadRequestResponse()
        {
            int? Id = 0;
            var homeController = new HomeController(new PeopleList());

            var result = homeController.Edit(Id) as BadRequestResult;

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        [Trait("Category", "Edit")]
        public void EditPost_InvalidModelState_ReturnsBadRequestResponse()
        {
            var homeController = new HomeController(new PeopleList());
            homeController.ModelState.AddModelError("SessionName", "Required");
            var person = new Person() { City = "Vetlanda", PhoneNumber = 123456789, Id = 6 };

            var result = homeController.Edit(person);

            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestObjectResult.Value);

        }

        [Fact]
        [Trait("Category", "Edit")]
        public void EditPost_ValidModelStateNoExistingId_ReturnsNotFoundResponse()
        {
            var homeController = new HomeController(new PeopleList());
            var person = new Person() { Id = 2, Name = "Micael Ståhle", City = "Viborg", PhoneNumber = 1237812 };

            var result = homeController.Edit(person);

            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        [Trait("Category", "Edit")]
        public void EditPost_ValidModelStateExistingId_ReturnsEditedPerson()
        {
            var homeController = new HomeController(new PeopleList());
            // Only changed the name, so if Name is valid, so should all other be.
            var person = new Person() { Id = 1, Name = "Testare Testsson", City = "Viborg", PhoneNumber = 12312313 };

            var result = homeController.Edit(person);

            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<Person>(viewResult.ViewData.Model);
            Assert.Equal(person.Name, model.Name);
        }


        [Fact]
        [Trait("Category", "Filter")]
        public void Filter_InvalidModelState_ReturnsBadRequestResponse()
        {
            var homeController = new HomeController(new PeopleList());
            homeController.ModelState.AddModelError("Filter", "Required");
            var pvm = new PersonViewModel()
            {
                Filter = null,
                PersonList = new List<Person>()
                {
                new Person() { Name = "test test", City = "test", Id = 2, PhoneNumber = 213 },
                new Person() { Name ="test testare", City="testsson", Id=3, PhoneNumber= 1212 }
                }
            };

            var result = homeController.Filter(pvm);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        [Trait("Category", "Filter")]
        public void Filter_FilterIsEmpty_ReturnsRedirectToAction()
        {
            var homeController = new HomeController(new PeopleList());
            var pvm = new PersonViewModel()
            {
                Filter = null,
                PersonList = new List<Person>()
                {
                new Person() { Name = "test test", City = "test", Id = 2, PhoneNumber = 213 },
                new Person() { Name ="test testare", City="testsson", Id=3, PhoneNumber= 1212 }
                }
            };

            var result = homeController.Filter(pvm);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        [Trait("Category", "Filter")]
        public void Filter_ModelStateIsValid_ReturnsPartialViewResultResponse()
        {
            var homeController = new HomeController(new PeopleList());
            var pvm = new PersonViewModel()
            {
                Filter = "test",
                PersonList = new List<Person>()
                {
                new Person() { Name = "test test", City = "test", Id = 2, PhoneNumber = 213 },
                new Person() { Name ="test testare", City="testsson", Id=3, PhoneNumber= 1212 }
                }
            };

            var result = homeController.Filter(pvm);

            Assert.IsType<PartialViewResult>(result);
        }

        [Fact]
        [Trait("Category", "Filter")]
        public void Filter_ModelStateIsValid_ReturnsString()
        {
            var homeController = new HomeController(new PeopleList());
            var pvm = new PersonViewModel()
            {
                Filter = "test",
                PersonList = new List<Person>()
                {
                new Person() { Name = "test test", City = "test", Id = 2, PhoneNumber = 213 },
                new Person() { Name ="test testare", City="testsson", Id=3, PhoneNumber= 1212 }
                }
            };

            var result = homeController.Filter(pvm);

            var partialViewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<PersonViewModel>(partialViewResult.ViewData.Model);
            Assert.Equal(pvm.Filter, model.Filter);
        }
    }
}
