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
            var user = userlist.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewData.Model = new Models.User();
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                var id = userlist.Count() + 1;
                user.Id = id;
                userlist.Add(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = userlist.FirstOrDefault(emp => emp.Id == id);
            return View(employee);
           
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                var employee = userlist.FirstOrDefault(emp => emp.Id == id);
                userlist.Remove(employee);
                employee.Name = user.Name;
                employee.Email = user.Email;
    
                userlist.Add(employee);
                return RedirectToAction("Index"); 
                
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
          
                var employee = userlist.FirstOrDefault(emp => emp.Id == id);
                userlist.Remove(employee);
                return RedirectToAction("Index");

               
            }
            catch
            {
                return View();
            }
        }
    }
}
