using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Solution.API.Controllers
{
    [Route("api/Employees")]
    public class EmployeesController : ApiController
    {
        private BS.Employees bs = new BS.Employees();
        // GET: api/Employees
        [Route("api/Employees/GetEmployees/")]
        [HttpGet]
        public IQueryable<Employees> GetEmployees()
        {
            //return db.Employees;
            return bs.GetAll().AsQueryable();
        }

        [Route("api/Employees/GetEmployees/5")]
        [HttpGet]
        // GET: api/Employees/5
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> GetEmployees(int id)
        {
            //Employees employees = await db.Employees.FindAsync(id);
            Employees employees =  bs.GetOneById(id);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployees(int id, Employees employees)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != employees.EmployeeID)
            {
                return BadRequest();
            }

            //db.Entry(employees).State = EntityState.Modified;
            // Llamar Update de BS 
            try
            {
                //await db.SaveChangesAsync();
                bs.Updated(employees);

            }
            catch (Exception ee)
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

        // POST: api/Employees
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> PostEmployees(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Employees.Add(employees);
            //await db.SaveChangesAsync();
            // LLamar BS hacer insert 
            bs.Insert(employees);
            Employees newEmp = bs.SearchByFirstName(employees.FirstName).LastOrDefault();
            return CreatedAtRoute("DefaultApi", new { id = newEmp.EmployeeID }, newEmp);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> DeleteEmployees(int id)
        {
            //Employees employees = await db.Employees.FindAsync(id);
            // Llamar BS  find by id 
            Employees employees = bs.GetOneById(id);
            if (employees == null)
            {
                return NotFound();
            }

            //db.Employees.Remove(employees);
            //await db.SaveChangesAsync();
            // Llamar BS Delete 
            bs.Delete(employees);

            return Ok(employees);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool EmployeesExists(int id)
        {
            // Llamar BS  find by id 
            //return db.Employees.Count(e => e.EmployeeID == id) > 0;
            //bs.GetOneById(id)!=null ? true:false;

            //if (bs.GetOneById(id) != null) {
            //    return true;
            //} else { 
            //    return false;
            //}

            return bs.GetOneById(id)!=null ? true:false;
        }
    }
}
