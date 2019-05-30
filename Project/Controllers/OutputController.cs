using Project.Models;
using System.Web.Mvc;
using System.Linq;

namespace Project.Controllers
{
    public class OutputController : Controller
    {
        private DataContext context;
        // GET: Output
        public ActionResult Index()
        {
            using (context = new DataContext())
            {
                
            }
            return View();
        }

        public ActionResult Tabels()
        {
            return View();
        }
    }
}