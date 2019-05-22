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
        public void Index_RequestListOfPeople_ReturnsListsOfPeople()
        {
            var homeController = new HomeController(new PeopleList());

            var result = homeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<PersonViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, model.PersonList.Count());
        }
    }
}
