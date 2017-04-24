using System.Web.Mvc;


namespace PeopleManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // var people = Database.People;
            return View();
        }

       
    }
}