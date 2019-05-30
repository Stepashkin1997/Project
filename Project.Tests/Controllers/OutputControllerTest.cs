using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Controllers;

namespace Project.Tests.Controllers
{
    [TestClass]
    public class OutputControllerTest
    {
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            OutputController controller = new OutputController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EmployeesViewResultNotNull()
        {
            OutputController controller = new OutputController();

            ViewResult result = controller.Employees() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ProjectsViewResultNotNull()
        {
            OutputController controller = new OutputController();

            ViewResult result = controller.Projects() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
