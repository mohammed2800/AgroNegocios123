using AgroNegocios.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgroNegocios.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            return View();
        }

        public ActionResult Users()
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            AgroNegociosEntities entity = new AgroNegociosEntities();
            var users = new List<Users>();
            users = entity.Users.ToList();

            return View(users);
        }

        public ActionResult Projects()
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            AgroNegociosEntities entity = new AgroNegociosEntities();
            var projects = new List<Projects>();
            projects = entity.Projects.ToList();

            return View(projects);
        }

        public ActionResult Team()
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            AgroNegociosEntities entity = new AgroNegociosEntities();
            var team = new List<Team>();
            team = entity.Team.ToList();

            return View(team);
        }

        public ActionResult TeamAddOrEdit(int id = 0)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            var teamMember = new Team();
            if (id != 0)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                teamMember = entity.Team.Where(x => x.id == id).FirstOrDefault();
            }

            return View(teamMember);
        }

        [HttpPost]
        public ActionResult TeamAdd(Team teamMember, HttpPostedFileBase file)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            var fileName = "";
            var path = "";
            if (file != null)
            {
                fileName = Path.GetFileName(file.FileName);
                path = Path.Combine(Server.MapPath("~/img/bg-img/"), fileName);
                file.SaveAs(path);
            }
            else
                fileName = "default-member.png";

            if (teamMember.name != null && teamMember.role != null)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                teamMember.image = fileName;
                entity.Team.Add(teamMember);
                entity.SaveChanges();
            }
            else
                return View("TeamAddOrEdit");

            return RedirectToAction("Team", "Admin");
        }

        [HttpPost]
        public ActionResult TeamEdit(Team teamMember, HttpPostedFileBase file)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            var fileName = "";
            var path = "";
            if (file != null)
            {
                fileName = Path.GetFileName(file.FileName);
                path = Path.Combine(Server.MapPath("~/img/bg-img/"), fileName);
                file.SaveAs(path);
            }
            else
                fileName = "default-member.png";

            if (teamMember.name != null && teamMember.role != null)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                var Member = entity.Team.Where(x => x.id == teamMember.id).FirstOrDefault();
                Member.name = teamMember.name;
                Member.role = teamMember.role;
                Member.image = fileName;
                entity.SaveChanges();
            }
            else
                return RedirectToAction("TeamAddOrEdit", "Admin", new { teamMember.id });

            return RedirectToAction("Team", "Admin");
        }

        public ActionResult TeamDelete(int ID)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            var teamMember = new Team();
            if (ID != 0)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                teamMember = entity.Team.Where(x => x.id == ID).FirstOrDefault();
                entity.Team.Remove(teamMember);
                entity.SaveChanges();
            }
            return RedirectToAction("Team", "Admin");
        }

        public ActionResult TeamPictureDelete(int ID)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            AgroNegociosEntities entity = new AgroNegociosEntities();
            var teamMember = entity.Team.Where(x => x.id == ID).FirstOrDefault();
            teamMember.image = "default-member.png";
            entity.SaveChanges();

            return RedirectToAction("Team", "Admin");
        }

        public ActionResult ProjectAddOrEdit(int id = 0)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            var project = new Projects();
            if (id != 0)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                project = entity.Projects.Where(x => x.ID == id).FirstOrDefault();
            }

            return View(project);
        }

        public ActionResult UserAddOrEdit(int id = 0)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            var user = new Users();
            if (id != 0)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                user = entity.Users.Where(x => x.ID == id).FirstOrDefault();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult UserAdd(Users user)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            if (user.FullName != null && user.UserName != null && user.Password != null)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                entity.Users.Add(user);
                entity.SaveChanges();
            }
            else
                return View("UserAddOrEdit");

            return RedirectToAction("Users", "Admin");
        }

        [HttpPost]
        public ActionResult UserEdit(Users user)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            if (user.FullName != null && user.UserName != null && user.Password != null)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                var User = entity.Users.Where(x => x.ID == user.ID).FirstOrDefault();
                User.FullName = user.FullName;
                User.UserName = user.UserName;
                User.Password = user.Password;
                entity.SaveChanges();
            }
            else
                return RedirectToAction("UserAddOrEdit", "Admin", new { user.ID });

            return RedirectToAction("Users", "Admin");
        }

        public ActionResult UserDelete(int ID)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            var user = new Users();
            if (ID != 0)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                user = entity.Users.Where(x => x.ID == ID).FirstOrDefault();
                entity.Users.Remove(user);
                entity.SaveChanges();
            }
            return RedirectToAction("Users", "Admin");
        }

        [HttpPost]
        public ActionResult ProjectAdd(Projects project, HttpPostedFileBase file)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            var fileName = "";
            var path = "";
            if (file != null)
            {
                fileName = Path.GetFileName(file.FileName);
                path = Path.Combine(Server.MapPath("~/img/"), fileName);
                file.SaveAs(path);
            }

            if (project.Title != null && project.Description != null)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                project.Picture = fileName;
                entity.Projects.Add(project);
                entity.SaveChanges();
            }
            else
                return View("ProjectAddOrEdit");

            return RedirectToAction("Projects", "Admin");
        }

        [HttpPost]
        public ActionResult ProjectEdit(Projects project, HttpPostedFileBase file)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            var fileName = "";
            var path = "";
            if (file != null)
            {
                fileName = Path.GetFileName(file.FileName);
                path = Path.Combine(Server.MapPath("~/img/"), fileName);
                file.SaveAs(path);
            }

            if (project.ID != 0 && project.Title != null && project.Description != null)
            {
                AgroNegociosEntities entity = new AgroNegociosEntities();
                var pro = entity.Projects.Where(x => x.ID == project.ID).FirstOrDefault();
                pro.Title = project.Title;
                pro.Picture = fileName;
                pro.Description = project.Description;
                pro.TitleInSpanish = string.IsNullOrEmpty(project.TitleInSpanish) ? "" : project.TitleInSpanish;
                pro.DescriptionInSpanish = string.IsNullOrEmpty(project.DescriptionInSpanish) ? "" : project.DescriptionInSpanish;

                entity.SaveChanges();
            }
            else
                return RedirectToAction("ProjectAddOrEdit", "Admin", new { project.ID });

            return RedirectToAction("Projects", "Admin");
        }

        public ActionResult ProjectDelete(int id = 0)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            if (id != 0)
            {
                var project = new Projects();
                AgroNegociosEntities entity = new AgroNegociosEntities();
                project = entity.Projects.Where(x => x.ID == id).FirstOrDefault();
                if (project != null)
                {
                    entity.Projects.Remove(project);
                    entity.SaveChanges();
                }
            }

            return RedirectToAction("Projects", "Admin");
        }

        public ActionResult ProjectPictureDelete(int ID)
        {
            if (!IsUserLoggedIn())
                return RedirectToAction("Index", "Login");

            AgroNegociosEntities entity = new AgroNegociosEntities();
            var pro = entity.Projects.Where(x => x.ID == ID).FirstOrDefault();
            pro.Picture = "";
            entity.SaveChanges();

            return RedirectToAction("Projects", "Admin");
        }

        protected bool IsUserLoggedIn()
        {
            HttpCookie cookie = Request.Cookies["UserModel"];
            if (cookie != null && cookie.Value != null)
                return true;

            return false;
        }

    }
}