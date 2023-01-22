using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using testest.Models;

namespace testest.Controllers

{

    [Authorize(Roles = "Admin")]
   
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager<IdentityRole> roleManager;

        public AdminController() { }
        public AdminController(RoleManager<IdentityRole> roleManager,ApplicationUserManager userManager)
        {
            UserManager = userManager;
            this.roleManager = roleManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: Admin
        public ActionResult Index()
        {
            /*var users = from u in db.Users
                        from ur in u.Roles
                        join r in db.Roles on ur.RoleId equals r.Id
                        select new
                        {
                            u.Id,
                            Name = u.UserName,
                            Role = r.Name,
                        };
            var test = users.ToArray();*/
                     //  System.Diagnostics.Debug.WriteLine("heyyyy hteree !!!!!!!!!!!!!!!: " + test[0]);

            //var allroles = System.Web.Security.Roles.GetAllRoles();
            //System.Diagnostics.Debug.WriteLine("heyyyy hteree !!!!!!!!!!!!!!!: " + allroles[0]);

            var users = db.Users.ToList();
            //  var allroles = db.AspNetRoles.ToList();
            //  var users = allroles.FindAll(x=>x.AspNetUsers);
            //var role =  db.Roles.Where(a=>a.Name =="User").FirstOrDefault();
            // var users = (IEnumerable<ApplicationUser>) roles.Users.AsEnumerable();
            /*var userrole = db.Roles.Where(a=>a.Name=="User").FirstOrDefault();
            var users1 = new List<ApplicationUser>();
            foreach (var user in users)
            {
                foreach(var r in user.Roles.GetRolesForUser()
                System.Diagnostics.Debug.WriteLine("heyyyy hteree !!!!!!!!!!!!!!!: "+r.RoleId);
                var listusers = user.Roles.ToString();
                if (listusers=="User")
                {
                    users1.Add(user);
                }
                
            }*/

            return View(users);
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var user = db.Users.Where(a => a.Id == id).FirstOrDefault();
                return View(user);
            }
            
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel usermodel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var user = new ApplicationUser
                    {
                        UserName = usermodel.Email, 
                        Email = usermodel.Email,
                        Prenom =    usermodel.Prenom,
                        Nom =   usermodel.Nom,
                        DateNaissance = usermodel.DateNaissance,
                    };
                    var result = await UserManager.CreateAsync(user, usermodel.Password);
                    var role = db.Roles.Where(a => a.Name == "User").FirstOrDefault();
                    if (role == null)
                    {
                        var newrole = new IdentityRole();
                        var newroleAdmin = new IdentityRole();
                        newrole.Name = "User";
                        newroleAdmin.Name = "Admin";
                        db.Roles.Add(newrole);
                        db.Roles.Add(newroleAdmin);
                        db.SaveChanges();
                    }
                    AddErrors(result);
                    if (result.Succeeded)
                    {
                        var result1 = await UserManager.AddToRoleAsync(user.Id, "User");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(usermodel);
                    }
                }
            }
            catch
            {
                return View(usermodel);
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var user = db.Users.Where(a => a.Id == id).FirstOrDefault();

                return View(user);
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ApplicationUser userupdated)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var user = db.Users.Where(a => a.Id == id).FirstOrDefault();
                    user.Nom = userupdated.Nom;
                    user.Prenom = userupdated.Prenom;
                    user.DateNaissance = userupdated.DateNaissance;
                   
                    db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(userupdated);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            var finduser = db.Users.Find(id);
            return View(finduser);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, ApplicationUser user)
        {
            try
            {
                var finduser = db.Users.Find(id);
                db.Users.Remove(finduser);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }
    }
}
