using AgroNegocios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AgroNegocios.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AgroNegociosEntities entity = new AgroNegociosEntities();
            var projects = new List<Projects>();
            projects = entity.Projects.ToList();

            return View(projects);
        }

        public ActionResult About()
        {
            AgroNegociosEntities entity = new AgroNegociosEntities();
            var team = new List<Team>();
            team = entity.Team.ToList();

            return View(team);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Projects()
        {
            AgroNegociosEntities entity = new AgroNegociosEntities();
            var projects = new List<Projects>();
            projects = entity.Projects.ToList();

            return View(projects);
        }

        public ActionResult WorkingMethods()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sendMail()
        {
            string Country = Request.Form["Country"];
            string CustomerName = Request.Form["CustomerName"];
            string Telephone = Request.Form["Telephone"];

            if (Country == null || Country == "" || CustomerName == "" || CustomerName == null || Telephone == "" || Telephone == null)
            {
                if (Country == "")
                    TempData["msg"] = "<script>alert('Country Is Requeired');</script>";
                else if (CustomerName == "")
                    TempData["msg"] = "<script>alert('Customer Name Is Requeired');</script>";
                else
                    TempData["msg"] = "<script>alert('Telephone Is Requeired');</script>";
            }
            else
            {
                string FarmName = Request.Form["FarmName"];
                string Location = Request.Form["Location"];
                string Fax = Request.Form["Fax"];
                string Email = Request.Form["Email"];
                string CropType = Request.Form["CropType"];
                string MinimumTemperature = Request.Form["MinimumTemperature"];
                string MaximumTemperature = Request.Form["MaximumTemperature"];
                string MaximumHumidity = Request.Form["MaximumHumidity"];
                string MinimumHumidity = Request.Form["MinimumHumidity"];
                string MaximumWide = Request.Form["MaximumWide"];
                string AverageAnnual = Request.Form["AverageAnnual"];
                string MaximumAverage = Request.Form["MaximumAverage"];
                string Altitude = Request.Form["Altitude"];
                string Tomatoes = Request.Form["Tomatoes"];
                string Peppers = Request.Form["Peppers"];
                string Cucumbers = Request.Form["Cucumbers"];
                string Strawberries = Request.Form["Strawberries"];
                string Roses = Request.Form["Roses"];
                string CostOfOffice = Request.Form["CostOfOffice"];
                string CostOfElectriCity = Request.Form["CostOfElectriCity"];
                string CostOfGas = Request.Form["CostOfGas"];
                string CostOfConcrete = Request.Form["CostOfConcrete"];
                string CostOfLabor = Request.Form["CostOfLabor"];
                string CostOfEngineer = Request.Form["CostOfEngineer"];
                string CostOfAgronomist = Request.Form["CostOfAgronomist"];
                string CostOfHouse = Request.Form["CostOfHouse"];
                string CostOfThreeTon = Request.Form["CostOfThreeTon"];
                string CostOfHalfTon = Request.Form["CostOfHalfTon"];
                string CostOfsubstrate = Request.Form["CostOfsubstrate"];
                string CostOfTransportation = Request.Form["CostOfTransportation"];

                var fromMail = new MailAddress("agro.negocios.official@gmail.com", "contact");
                var toMail = new MailAddress("info@agro-negocios.net");
                var fromEmailPassword = "159753Asd";
                var br = "</br>";
                string subject = "contact us";
                string body =
                    br + "<h2>Country: " + Country
                    + "</h2>" + br + "<h2>Customer Name: " + CustomerName
                    + "</h2>" + br + "<h2>Farm Name: " + FarmName + "</h2>"
                    + "</h2>" + br + "<h2>Location: " + Location + "</h2>"
                    + "</h2>" + br + "<h2>Telephone: " + Telephone + "</h2>"
                    + "</h2>" + br + "<h2>Fax: " + Fax + "</h2>"
                    + "</h2>" + br + "<h2>Email: " + Email + "</h2>"
                    + "</h2>" + br + "<h2>Crop Type/s: " + CropType + "</h2>"
                    + "</h2>" + br + "<h2>Minimum Temperature: " + MinimumTemperature + "</h2>"
                    + "</h2>" + br + "<h2>Maximum Temperature: " + MaximumTemperature + "</h2>"
                    + "</h2>" + br + "<h2>Maximum Humidity: " + MaximumHumidity + "</h2>"
                    + "</h2>" + br + "<h2>Minimum Humidity: " + MinimumHumidity + "</h2>"
                    + "</h2>" + br + "<h2>Maximum Wide Speed: " + MaximumWide + "</h2>"
                    + "</h2>" + br + "<h2>Average Annual Rainfall: " + AverageAnnual + "</h2>"
                    + "</h2>" + br + "<h2>Maximum Average Rainfall Per Hour: " + MaximumAverage + "</h2>"
                    + "</h2>" + br + "<h2>Altitude: " + Altitude + "</h2>"
                    + "</h2>" + br + "<h2>Tomatoes: " + Tomatoes + "</h2>"
                    + "</h2>" + br + "<h2>Peppers: " + Peppers + "</h2>"
                    + "</h2>" + br + "<h2>Cucumbers: " + Cucumbers + "</h2>"
                    + "</h2>" + br + "<h2>Strawberries: " + Strawberries + "</h2>"
                    + "</h2>" + br + "<h2>Roses: " + Roses + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of Office: " + CostOfOffice + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of ElectriCity: " + CostOfElectriCity + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of Gas: " + CostOfGas + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of Concrete: " + CostOfConcrete + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of Labor: " + CostOfLabor + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of Engineer: " + CostOfEngineer + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of Agronomist: " + CostOfAgronomist + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of House: " + CostOfHouse + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of 3 Ton Forklift: " + CostOfThreeTon + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of 1.5 Ton Forklift: " + CostOfHalfTon + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of substrate: " + CostOfsubstrate + "</h2>"
                    + "</h2>" + br + "<h2>Cost Of Transportation: " + CostOfTransportation + "</h2>";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromMail.Address, fromEmailPassword)
                };

                using (var message = new MailMessage(fromMail, toMail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                    smtp.Send(message);
            }

            return View("Contact");
        }

        [HttpPost]
        public ActionResult sendContactMail()
        {
            string country = Request.Form["country"];
            string CustomerName = Request.Form["name"];
            string phone = Request.Form["phone"];
            string message = Request.Form["message"];

            if (CustomerName == "" || CustomerName == null || phone == "" || phone == null)
            {
                if (CustomerName == "")
                    TempData["msg"] = "<script>alert('Name Is Requeired');</script>";
                else if (phone == "")
                    TempData["msg"] = "<script>alert('phone Is Requeired');</script>";
            }
            else
            {
                var fromMail = new MailAddress("agro.negocios.official@gmail.com", "contact");
                var toMail = new MailAddress("info@agro-negocios.net");
                var fromEmailPassword = "159753Asd";
                var br = "</br>";
                string subject = "contact us";
                string body =
                    br + "<h2>Customer Name: " + CustomerName
                    + "</h2>" + br + "<h2>Country: " + country
                    + "</h2>" + br + "<h2>Phone: " + phone 
                    + "</h2>" + br + "<h2>Message: " + message + "</h2>";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromMail.Address, fromEmailPassword)
                };

                using (var MailMessage = new MailMessage(fromMail, toMail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                    smtp.Send(MailMessage);
            }

            return View("contact");
        }
    }
}