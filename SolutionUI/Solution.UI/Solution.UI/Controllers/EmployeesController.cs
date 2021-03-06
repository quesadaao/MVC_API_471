﻿using Newtonsoft.Json;
using Solution.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Solution.UI.Controllers
{
    public class EmployeesController : Controller
    {
        string baseurl = "http://localhost:44322/";

        // GET: Employees
        public ActionResult IndexAsync34444353()
        {
            //return View(db.Employees.ToList());
            List<Employees> aux = new List<Employees>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = client.GetAsync("api/Employees");

                var result = client.GetAsync("api/Employees/GetEmployees");
                result.Wait();
                var res = result.Result;
                if (res.IsSuccessStatusCode)
                {
                    var auxRes = res.Content.ReadAsStringAsync().Result;

                    aux = JsonConvert.DeserializeObject<List<Employees>>(auxRes);
                }
            }
            return View(aux);
            //return null;
        }

        public ActionResult IndexAsync222()
        {
            IEnumerable<Employees> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44322/");
                //HTTP GET
                var responseTask = client.GetAsync("api/Employees/GetEmployees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<IList<Employees>>();
                    //readTask.Wait();

                    //students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<Employees>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(students);
        }

        public ActionResult IndexAsync() {
            IEnumerable<Employees> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44322/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Employees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<IList<Employees>>();
                    //readTask.Wait();

                    //students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<Employees>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(students);
 
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Employees employees = db.Employees.Find(id);
            //if (employees == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(employees);
            return View();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                //db.Employees.Add(employees);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Employees employees = db.Employees.Find(id);
            //if (employees == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(employees);
            return View();
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(employees).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Employees employees = db.Employees.Find(id);
            //if (employees == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(employees);
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Employees employees = db.Employees.Find(id);
            //db.Employees.Remove(employees);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}