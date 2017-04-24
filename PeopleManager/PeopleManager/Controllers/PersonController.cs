using System.Linq;
using System.Web.Mvc;
using PeopleManager.DataAccess;
using PeopleManager.Model;

namespace PeopleManager.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonDataAccessor personDataAccessor;

        public PersonController()
        {
            personDataAccessor = new PersonDataAccessor();
        }
        private object person;
        private object dbPerson;

        // GET: Person
        public ActionResult Index()
        {
            //var people = Database.People;

           // return View(people);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
           // person.Id = GetNewPersonId();
           // Database.People.Add(person);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
           // var person = Database.People.SingleOrDefault(p => p.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
           // var dbPerson = Database.People.SingleOrDefault(p => p.Id == person.Id);
            //Person dbPerson = null;
            //foreach (Person p in Database.People)
            //{
            //    if (p.Id == person.Id)
            //    {
            //        dbPerson = p;
            //        break;
            //    }
            //}

            //If dbPerson is not found in the database, FLEE!
            if (dbPerson == null)
            {
                return HttpNotFound();
            }

            dbPerson.FirstName = person.FirstName;
            dbPerson.Name = person.Name;
            dbPerson.Email = person.Email;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
           // var person = Database.People.SingleOrDefault(p => p.Id == id);
            return View(person);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteConfirmation(int id)
        {
           // var dbPerson = Database.People.SingleOrDefault(p => p.Id == id);
           // Database.People.Remove(dbPerson);

            return RedirectToAction("Index");
        }

        //private int GetNewPersonId()
        //{
        // ////   if (!Database.People.Any())
        // //   {
        // //       return 1;
        // //   }
        // //   var highestId = Database.People.Max(p => p.Id);
        // //   highestId++;
        // //   return highestId;
        //}
    }
}