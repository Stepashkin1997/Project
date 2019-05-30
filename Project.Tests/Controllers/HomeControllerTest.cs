using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Controllers;
using System.Web.Mvc;

namespace Project.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;
            var a = result.ViewName;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
