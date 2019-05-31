using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Controllers;

namespace Project.Tests.Controllers
{
    [TestClass]
    public class UpdateControllerTest
    {
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            UpdateController controller = new UpdateController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ResultViewBagList()
        {
            UpdateController controller = new UpdateController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.ViewBag.List);
        }
    }
}
