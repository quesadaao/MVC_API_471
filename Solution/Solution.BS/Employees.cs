using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DAL.EF;
using ent = Solution.DO.Objects;
using Solution.DO.Interfases;
using Solution.DAL;
using Solution.Maps;
using System.Linq.Expressions;
using AutoMapper;

namespace Solution.BS
{
    public class Employees : ICRUD<ent.Employees>
    {
        private DAL.Employees _dal = new DAL.Employees();
        public void Delete(ent.Employees t)
        {
            var _ent = Mapper.Map<ent.Employees, data.Employees>(t);
            _dal.Delete(_ent);
        }

        public IEnumerable<ent.Employees> GetAll()
        {
            var t = _dal.GetAll();
            var _ent = Mapper.Map<IEnumerable<data.Employees>, IEnumerable<ent.Employees>>(t);
            return _ent;
        }

        public ent.Employees GetOneById(int id)
        {
            var t = _dal.GetOneById(id);
            var _ent = Mapper.Map<data.Employees, ent.Employees>(t);
            return _ent;
        }

        public void Insert(ent.Employees t)
        {
            var _ent = Mapper.Map<ent.Employees, data.Employees>(t);
            _dal.Insert(_ent);
        }

        public IEnumerable<ent.Employees> SearchByFirstName(string FirstName)
        {
            var t = _dal.SearchByFirstName(FirstName);
            var _ent = Mapper.Map<IEnumerable<data.Employees>, IEnumerable<ent.Employees>>(t);
            return _ent;
        }

        public IEnumerable<ent.Employees> Search(Expression<Func<ent.Employees, bool>> predicado)
        {
            return null;
        }

        public void Updated(ent.Employees t)
        {
            var _ent = Mapper.Map<ent.Employees, data.Employees>(t);
            _dal.Updated(_ent);
        }
    }
}
