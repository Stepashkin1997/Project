using Project.Models;
using System.Linq;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class UpdateController : Controller
    {
        private DataContext context;
        // GET: Update
        public ActionResult Index()
        {
            using (context = new DataContext())
            {
                var a = context.Employee.ToList();
            }

            return View();
        }
    }
}