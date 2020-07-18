using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Solution.API.W.Models;

namespace Solution.API.W.Controllers
{
    public class EmployeesAsyncController : ApiController
    {
        private Northwind2Entities1 db = new Northwind2Entities1();

        // GET: api/EmployeesAsync
        public IQueryable<Employees> GetEmployees()
        {
            return db.Employees;
        }

        // GET: api/EmployeesAsync/5
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> GetEmployees(int id)
        {
            Employees employees = await db.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        // PUT: api/EmployeesAsync/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployees(int id, Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employees.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(employees).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmployeesAsync
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> PostEmployees(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employees);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employees.EmployeeID }, employees);
        }

        // DELETE: api/EmployeesAsync/5
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> DeleteEmployees(int id)
        {
            Employees employees = await db.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employees);
            await db.SaveChangesAsync();

            return Ok(employees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeesExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeID == id) > 0;
        }
    }
}