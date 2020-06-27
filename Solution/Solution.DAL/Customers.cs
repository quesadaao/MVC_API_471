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
        public class Customers : ICRUD<data.Customers>
        {
            private Repository<data.Customers> _repository = new Repository<data.Customers>(new Northwind2Entities());
            public void Delete(data.Customers t)
            {
                try
                {
                    //t.PhotoPath = true.ToString();
                    //_repository.Updated(t);

                    _repository.Delete(t);
                    _repository.Commit();
                }
                catch (Exception ee)
                {
                    throw;
                }
            }

            public IEnumerable<data.Customers> GetAll()
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

            public data.Customers GetOneById(int id)
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

            public void Insert(data.Customers t)
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

            //public IEnumerable<data.Customers> SearchByFirstName(string FirstName)
            //{
            //    try
            //    {
            //        return _repository.Search(p => p.FirstName.Contains(FirstName));
            //    }
            //    catch (Exception ee)
            //    {
            //        throw;
            //    }
            //}

            public IEnumerable<data.Customers> Search(Expression<Func<data.Customers, bool>> predicado)
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

            public void Updated(data.Customers t)
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


