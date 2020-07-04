using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DAL.EF;

namespace Solution.DAL
{
    public class Employees : ICRUD<data.Employees>
    {
        private Repository<data.Employees> _repository = new Repository<data.Employees>(new Northwind2Entities());
        public void Delete(data.Employees t)
        {
            try
            {
                //t.PhotoPath = true.ToString();
                //_repository.Updated(t);

                _repository.Delete(t.EmployeeID);
                _repository.Commit();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public IEnumerable<data.Employees> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public data.Employees GetOneById(int id)
        {
            try
            {
                return _repository.GetOneByID(id);                
            }
            catch (Exception ee)
            {
                throw;
            };
        }

        public void Insert(data.Employees t)
        {
            try
            {
                _repository.Insert(t);
                _repository.Commit();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public IEnumerable<data.Employees> SearchByFirstName(string FirstName)
        {
            try
            {
                return _repository.Search(p => p.FirstName.Contains(FirstName));
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public IEnumerable<data.Employees> Search(Expression<Func<data.Employees, bool>> predicado)
        {
            try
            {
                return _repository.Search(predicado);
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public void Updated(data.Employees t)
        {
            try
            {
                _repository.Updated(t);
                _repository.Commit();
            }
            catch (Exception ee)
            {
                throw;
            }
        }
    }
}
