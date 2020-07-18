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
    [Route("api/EmployeesRoutes")]
    public class EmployeesRoutesController : ApiController
    {
        private BS.Employees bs = new BS.Employees();

        [Route("api/EmployeesRoutes/Employees")]
        // GET: api/EmployeesRoutes
        public IQueryable<Employees> GetEmployees()
        {
            return bs.GetAll().AsQueryable();
        }

        [Route("api/EmployeesRoutes/5")]
        // GET: api/EmployeesRoutes/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult GetEmployees(int id)
        {
            Employees employees = bs.GetOneById(id);
            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        [Route("api/EmployeesRoutes/5")]
        // PUT: api/EmployeesRoutes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployees(int id, Employees employees)
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

        [Route("api/EmployeesRoutes")]
        // POST: api/EmployeesRoutes
        [ResponseType(typeof(Employees))]
        public IHttpActionResult PostEmployees(Employees employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bs.Insert(employees);
            Employees newEmp = bs.SearchByFirstName(employees.FirstName).LastOrDefault();
            return CreatedAtRoute("DefaultApi", new { id = newEmp.EmployeeID }, newEmp);
        }

        [Route("api/EmployeesRoutes/5")]
        // DELETE: api/EmployeesRoutes/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult DeleteEmployees(int id)
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
