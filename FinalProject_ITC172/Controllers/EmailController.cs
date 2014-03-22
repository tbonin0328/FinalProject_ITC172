using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject_ITC172.Models;

namespace FinalProject_ITC172.Controllers
{
    public class EmailController : Controller
    {
        //
        // GET: /Email/
        CommunityAssistEntities cae = new CommunityAssistEntities();

        public ActionResult Index()
        {
            
            var donors = from d in cae.Donations
                            orderby d.Person.PersonLastName
                            select new
                            {
                                d.Person.PersonLastName,
                                d.Person.PersonFirstName,
                                d.Person.PersonUsername,
                                d.DonationAmount,
                                d.DonationDate
                            };

            List<DonorEmails> donorList = new List<DonorEmails>();
            foreach (var x in donors)
            {
                DonorEmails de = new DonorEmails();
                de.LastName = x.PersonLastName;
                de.FirstName = x.PersonFirstName;
                de.Email = x.PersonUsername;
                de.DonationAmount = x.DonationAmount.ToString();
                de.DonationDate = x.DonationDate.ToString();
                
                donorList.Add(de);
            }

            return View(donorList);
        }

        public ActionResult Create()
        {
            ViewBag.DonationKey = new SelectList(cae.Donations, "DonationAmount", "DonationDate");
            ViewBag.PersonKey = new SelectList(cae.People, "PersonKey", "PersonLastName");
            return View();
        }

        //
        // POST: /CADonor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Donation donation)
        {
            if (ModelState.IsValid)
            {
                cae.Donations.Add(donation);
                cae.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeKey = new SelectList(cae.Donations, "DonationAmount", "DonationDate", donation.DonationKey);
            ViewBag.PersonKey = new SelectList(cae.People, "PersonKey", "PersonLastName", donation.PersonKey);
            return View(donation);
        }
    }
}
