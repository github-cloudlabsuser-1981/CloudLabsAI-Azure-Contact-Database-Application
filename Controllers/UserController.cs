using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
      

        public ActionResult Index()
        {
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            User user = userlist.Find(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }



        // GET: User/Edit/5
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            User user = userlist.Find(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = userlist.Find(u => u.Id == id);
                if (existingUser != null)
                {
                    // Update the existing user's data
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    // Add other properties as needed

                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }
  

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            User user = userlist.Find(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = userlist.Find(u => u.Id == id);
            if (user != null)
            {
                userlist.Remove(user);
            }
            return RedirectToAction("Index");
        }
 
    }
}
