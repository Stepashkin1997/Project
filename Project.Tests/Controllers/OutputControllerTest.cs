using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Controllers;

namespace Project.Tests.Controllers
{
    [TestClass]
    public class OutputControllerTest//тест-методы контроллера OutputController
    {
        [TestMethod]
        public void IndexViewResultNotNull()//проверка результата метода Index на пустоту
        {
            OutputController controller = new OutputController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EmployeesViewResultNotNull()//проверка результата метода Employees на пустоту
        {
            OutputController controller = new OutputController();

            ViewResult result = controller.Employees() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ProjectsViewResultNotNull()//проверка результата метода Projects на пустоту
        {
            OutputController controller = new OutputController();

            ViewResult result = controller.Projects() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ResultViewBagEmployeesNotNull()//проверка Employees контейнера ViewBag метода Employees на пустоту
        {
            OutputController controller = new OutputController();

            ViewResult result = controller.Employees() as ViewResult;

            Assert.IsNotNull(result.ViewBag.Employees);
        }

        [TestMethod]
        public void ResultViewBagProjectsNotNull()//проверка Projects контейнера ViewBag метода Projects на пустоту
        {
            OutputController controller = new OutputController();

            ViewResult result = controller.Projects() as ViewResult;

            Assert.IsNotNull(result.ViewBag.Projects);
        }
    }
}
