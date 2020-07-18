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
    public class EmployeesAsyncController : ApiController
    {
        private BS.Employees bs = new BS.Employees();
        // GET: api/EmployeesAsync
        public IQueryable<Employees> GetEmployees()
        {
            return bs.GetAll().AsQueryable();
        }

        // GET: api/EmployeesAsync/5
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> GetEmployees(int id)
        {
            Employees employees = bs.GetOneById(id);
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
            if (id != employees.EmployeeID)
            {
                return BadRequest();
            }

            try
            {
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

        // POST: api/EmployeesAsync
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> PostEmployees(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bs.Insert(employees);
            Employees newEmp = bs.SearchByFirstName(employees.FirstName).LastOrDefault();
            return CreatedAtRoute("DefaultApi", new { id = newEmp.EmployeeID }, newEmp);
        }

        // DELETE: api/EmployeesAsync/5
        [ResponseType(typeof(Employees))]
        public async Task<IHttpActionResult> DeleteEmployees(int id)
        {
            Employees employees = bs.GetOneById(id);
            if (employees == null)
            {
                return NotFound();
            }
            bs.Delete(employees);
            return Ok(employees);
        }

        private bool EmployeesExists(int id)
        {
            return bs.GetOneById(id) != null ? true : false;
        }
    }
}
