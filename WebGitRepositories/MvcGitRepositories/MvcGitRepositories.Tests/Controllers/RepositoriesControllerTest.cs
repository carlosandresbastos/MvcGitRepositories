using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcGitRepositories.Controllers;
using System.Web.Mvc;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
namespace MvcGitRepositories.Tests.Controllers
{
    [TestClass]
    public class RepositoriesControllerTest
    {
        [TestMethod]
      public void MyRepositories()
        {
            // Arrange
            RepositoriesController controller = new RepositoriesController();

            // Act
            ViewResult result = controller.MyRepositories() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FavoritesRepositories()
        {
            // Arrange
            RepositoriesController controller = new RepositoriesController();

            // Act
            ViewResult result = controller.FavoritesRepositories() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SearchRepositories()
        {
            // Arrange
            RepositoriesController controller = new RepositoriesController();

            // Act
            ViewResult result = controller.SearchRepositories() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
