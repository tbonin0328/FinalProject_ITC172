﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject_ITC172.Models;

namespace FinalProject_ITC172.Controllers
{
    public class CADonorController : Controller
    {
        private CommunityAssistEntities db = new CommunityAssistEntities();

        //
        // GET: /CADonor/

        public ActionResult Index()
        {
            var donations = db.Donations.Include(d => d.Employee).Include(d => d.Person);
            return View(donations.ToList());
        }

        //
        // GET: /CADonor/Details/5

        public ActionResult Details(int id = 0)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        //
        // GET: /CADonor/Create

        public ActionResult Create()
        {
            ViewBag.EmployeeKey = new SelectList(db.Employees, "EmployeeKey", "EmployeeSSNumber");
            ViewBag.PersonKey = new SelectList(db.People, "PersonKey", "PersonLastName");
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
                db.Donations.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeKey = new SelectList(db.Employees, "EmployeeKey", "EmployeeSSNumber", donation.EmployeeKey);
            ViewBag.PersonKey = new SelectList(db.People, "PersonKey", "PersonLastName", donation.PersonKey);
            return View(donation);
        }

        //
        // GET: /CADonor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeKey = new SelectList(db.Employees, "EmployeeKey", "EmployeeSSNumber", donation.EmployeeKey);
            ViewBag.PersonKey = new SelectList(db.People, "PersonKey", "PersonLastName", donation.PersonKey);
            return View(donation);
        }

        //
        // POST: /CADonor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeKey = new SelectList(db.Employees, "EmployeeKey", "EmployeeSSNumber", donation.EmployeeKey);
            ViewBag.PersonKey = new SelectList(db.People, "PersonKey", "PersonLastName", donation.PersonKey);
            return View(donation);
        }

        //
        // GET: /CADonor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        //
        // POST: /CADonor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}